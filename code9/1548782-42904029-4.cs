    public class TypeReplacer : ExpressionVisitor
    {
        public readonly Dictionary<Type, Type> Conversions = new Dictionary<Type, Type>();
        private readonly Dictionary<Expression, Expression> ParameterConversions = new Dictionary<Expression, Expression>();
        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            Type to;
            if (Conversions.TryGetValue(node.Member.DeclaringType, out to))
            {
                var member = ConvertMember(node.Member, to);
                node = Expression.Bind(member, node.Expression);
            }
            return base.VisitMemberAssignment(node);
        }
        protected override Expression VisitNew(NewExpression node)
        {
            Type to;
            if (Conversions.TryGetValue(node.Type, out to))
            {
                var constructor = node.Constructor;
                BindingFlags bf = (constructor.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic) |
                    BindingFlags.Instance;
                var parameters = constructor.GetParameters();
                var types = Array.ConvertAll(parameters, x => x.ParameterType);
                var constructor2 = to.GetConstructor(bf, null, types, null);
                // Shouldn't happen. node.Members != null with anonymous types
                if (node.Members != null)
                {
                    IEnumerable<MemberInfo> members = node.Members.Select(x => ConvertMember(x, to));
                    node = Expression.New(constructor2, node.Arguments, members);
                }
                else
                {
                    node = Expression.New(constructor2, node.Arguments);
                }
            }
            return base.VisitNew(node);
        }
        public override Expression Visit(Expression node)
        {
            if (node.NodeType == ExpressionType.Lambda)
            {
                var lambda = (LambdaExpression)node;
                var parameters = lambda.Parameters.ToArray();
                for (int i = 0; i < parameters.Length; i++)
                {
                    ParameterExpression parameter = parameters[i];
                    Type to;
                    if (Conversions.TryGetValue(parameter.Type, out to))
                    {
                        var oldParameter = parameter;
                        parameter = Expression.Parameter(to, parameter.Name);
                        parameters[i] = parameter;
                        ParameterConversions.Add(oldParameter, parameter);
                    }
                }
                // Handling of the delegate type
                var arguments = node.Type.GetGenericArguments();
                {
                    Type to;
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        if (Conversions.TryGetValue(arguments[i], out to))
                        {
                            arguments[i] = to;
                        }
                    }
                }
                var delegateType = node.Type.GetGenericTypeDefinition().MakeGenericType(arguments);
                var body = base.Visit(lambda.Body);
                node = Expression.Lambda(delegateType, body, parameters);
            }
            return base.Visit(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            Type to = null;
            Expression expression = null;
            if (node.Expression != null)
            {
                if (ParameterConversions.TryGetValue(node.Expression, out expression))
                {
                    to = expression.Type;
                }
            }
            if (to != null || (node.Expression == null && Conversions.TryGetValue(node.Member.DeclaringType, out to)))
            {
                MemberInfo member = ConvertMember(node.Member, to);
                node = Expression.MakeMemberAccess(expression, member);
            }
            return base.VisitMember(node);
        }
        // Conversion of method/property/field accessor (supported indexers)
        private static MemberInfo ConvertMember(MemberInfo member, Type to)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    {
                        var field = (FieldInfo)member;
                        BindingFlags bf = (field.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic) |
                            (field.IsStatic ? BindingFlags.Static : BindingFlags.Instance);
                        var field2 = to.GetField(member.Name, bf);
                        return field2;
                    }
                case MemberTypes.Property:
                    {
                        var prop = (PropertyInfo)member;
                        var method = prop.GetMethod ?? prop.SetMethod;
                        BindingFlags bf = (method.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic) |
                            (method.IsStatic ? BindingFlags.Static : BindingFlags.Instance);
                        var indexes = prop.GetIndexParameters();
                        var types = Array.ConvertAll(indexes, x => x.ParameterType);
                        var property2 = to.GetProperty(member.Name, bf, null, prop.PropertyType, types, null);
                        return property2;
                    }
                case MemberTypes.Method:
                    {
                        var method = (MethodInfo)member;
                        BindingFlags bf = (method.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic) |
                            (method.IsStatic ? BindingFlags.Static : BindingFlags.Instance);
                        var parameters = method.GetParameters();
                        var types = Array.ConvertAll(parameters, x => x.ParameterType);
                        var method2 = to.GetMethod(member.Name, bf, null, types, null);
                        return method2;
                    }
                default:
                    throw new NotSupportedException(member.MemberType.ToString());
            }
        }
    }
