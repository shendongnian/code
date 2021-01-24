    interface IWithMetadataMapping
    {
        int MapId { get; set; }
    }
    public static class Extensions 
    {
        private static MethodInfo GenerateMapIdMethodInfo = typeof(Extensions).GetMethod(nameof(GenerateMapId));
        public static int GenerateMapId()
        {
            throw new NotSupportedException("Should not be invoked directly");
        }
        static Dictionary<Mapping, int> MappingLookup = new Dictionary<Mapping, int>();
        static List<Mapping> Mappings = new List<Mapping>();
        public static Mapping GetMapping(int index)
        {
            return Mappings[index];
        }
        public class Mapping
        {
            public Mapping(Dictionary<MemberInfo, MemberInfo[]> propertyMappings)
            {
                this.propertyMappings = propertyMappings;
                int hc = propertyMappings.Count;
                foreach (var kv in propertyMappings)
                {
                    hc = unchecked(hc * 314159 + kv.Key.GetHashCode());
                    hc = unchecked(hc * 314159 + kv.Value.Length);
                    foreach (var pi in kv.Value)
                    {
                        hc = unchecked(hc * 314159 + pi.GetHashCode());
                    }
                }
                this.hashCode = hc;
            }
            private Dictionary<MemberInfo, MemberInfo[]> propertyMappings;
            private int hashCode;
            public override int GetHashCode() => this.hashCode;
            public override bool Equals(object obj)
            {
                if(obj is Mapping map)
                {
                    return map.propertyMappings.Count == this.propertyMappings.Count &&
                        map.propertyMappings.Keys.SequenceEqual(this.propertyMappings.Keys) &&
                        map.propertyMappings.Values
                            .Zip(this.propertyMappings.Values, (a, b) => a.SequenceEqual(b))
                            .All(v => v);
                }
                return false;
            }
            public MemberInfo[] GetSourceMemberChain(MemberInfo pi)
            {
                return this.propertyMappings[pi];
            }
            public bool TryGetSourceMemberChain(MemberInfo pi, out MemberInfo[] source)
            {
                return this.propertyMappings.TryGetValue(pi, out source) ;
            }
            
            public MemberInfo GetSourceMember(MemberInfo pi)
            {
                return this.GetSourceMemberChain(pi).First();
            }
            public bool TryGetSourceMember(MemberInfo pi, out MemberInfo source)
            {
                if(this.propertyMappings.TryGetValue(pi, out var sources))
                {
                    source = sources.First();
                    return true;
                }
                else
                {
                    source = null;
                    return false;
                }
            }
        }
        public static IQueryable<TResult> WithAttributeProjection<TSource, TResult>(this IQueryable<TSource> @this, Expression<Func<TSource, TResult>> selector)
        {
            var visitor = new MapExtractionVisitor();
            var newExpression = (Expression<Func<TSource, TResult>>)visitor.Visit(selector);
            
            return @this.Select(newExpression);
        }
        public class MapExtractionVisitor : ExpressionVisitor
        {
            List<MemberInfo> capturedMemebers;
            bool capturePropAccess = false;
            protected void CreateMapping(int count, 
                Func<int, Expression> getValue,
                Action<int, Expression> setValue,
                Func<int, MemberInfo> getMemeber,
                Func<int, bool> isGenerateMapId,
                bool alwaysExtractMap,
                out bool isDirty)
            {
                var mappingIdMember = -1;
                isDirty = false;
                Dictionary<MemberInfo, MemberInfo[]> propertyMappings = new Dictionary<MemberInfo, MemberInfo[]>();
                
                for (int index = 0; index < count; index++)
                {
                    
                    if (isGenerateMapId(index))
                    {
                        mappingIdMember = index;
                    }
                    var arg = getValue(index);
                    if (arg == null) continue;
                    var originalCapturePropAccess = this.capturePropAccess;
                    var originalCapturedMemebers = this.capturedMemebers;
                    this.capturePropAccess = true;
                    this.capturedMemebers = new List<MemberInfo>();
                    var newArgument = this.Visit(arg);
                    setValue(index, newArgument);
                    isDirty = isDirty || newArgument != arg;
                    if (this.capturedMemebers.Any())
                    {
                        propertyMappings.Add(getMemeber(index), this.capturedMemebers.ToArray());
                    }
                    this.capturedMemebers = originalCapturedMemebers;
                    this.capturePropAccess = originalCapturePropAccess;
                }
                if (mappingIdMember != -1 || alwaysExtractMap)
                {
                    lock (MappingLookup)
                    {
                        var newMapping = new Mapping(propertyMappings);
                        if (!MappingLookup.TryGetValue(newMapping, out var mapId))
                        {
                            mapId = Mappings.Count;
                            Mappings.Add(newMapping);
                            MappingLookup.Add(newMapping, mapId);
                        }
                        setValue(mappingIdMember, Expression.Constant(mapId));
                    }
                    isDirty = true;
                }
            }
            protected override Expression VisitNew(NewExpression node)
            {
                if (node.Members != null)
                {
                    Expression[] newArguments = new Expression[node.Arguments.Count];
                    CreateMapping(node.Arguments.Count, 
                        i => node.Arguments[i], 
                        (i, e) => newArguments[i] = e, 
                        i => node.Members[i],
                        i => node.Arguments[i] is MethodCallExpression mArg && mArg.Method == GenerateMapIdMethodInfo,
                        false,
                        out var isDirty);
                    if (isDirty)
                    {
                        return node.Update(newArguments);
                    }
                    else
                    {
                        return node;
                    }
                }
                else
                {
                    return base.VisitNew(node);
                }
            }
            protected override Expression VisitMemberInit(MemberInitExpression node)
            {
                Expression[] newArguments = new Expression[node.Bindings.Count + 1];
                var bindings = node.Bindings;
                var implementsInterface = typeof(IWithMetadataMapping).IsAssignableFrom(node.Type);
                CreateMapping(bindings.Count,
                     i => bindings[i] is MemberAssignment ma ? ma.Expression : null,
                     (i, e) => newArguments[i != -1 ? i : (newArguments.Length - 1)] = e,
                     i => bindings[i] is MemberAssignment ma ? ma.Member : null,
                     i =>
                     {
                         if (bindings[i] is MemberAssignment ma)
                         {
                             if (ma.Expression is MethodCallExpression mArg && mArg.Method == GenerateMapIdMethodInfo)
                             {
                                 return true;
                             }
                         }
                         return false;
                     },
                     implementsInterface,
                     out var isDirty);
                if (isDirty)
                {
                    int count = node.Bindings.Count;
                    bool addBinding = newArguments.Last() != null;
                    var inits = new MemberBinding[count + (addBinding ? 1 : 0)];
                    for (int i = 0; i < count; i++)
                    {
                        var binding = node.Bindings[i];
                        if (newArguments[i] == null)
                        {
                            inits[i] = binding;
                        }
                        else if(binding is MemberAssignment m)
                        {
                            inits[i] = Expression.Bind(m.Member, newArguments[i]);
                        }
                    }
                    if(addBinding)
                    {
                        var mapProp = node.Type.GetProperty(nameof(IWithMetadataMapping.MapId));
                        inits[inits.Length - 1] = Expression.Bind(mapProp, newArguments.Last());
                    }
                    return node.Update(node.NewExpression, inits);
                }
                return base.VisitMemberInit(node);
            }
            public override Expression Visit(Expression node)
            {
                // We only capture an interupted chanin of member accesses
                if(capturePropAccess && node is MemberExpression memberExpression)
                {
                    capturedMemebers.Add(memberExpression.Member);
                }
                else
                {
                    capturePropAccess = false;
                }
                return base.Visit(node);
            }
        }
    }
