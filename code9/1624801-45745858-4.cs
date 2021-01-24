        public class FieldSelector<T>
        {
            private List<LambdaExpression> expressions;
            public FieldSelector()
            {
                expressions = new List<LambdaExpression>();
            }
            public void Add(Expression<Func<T, object>> expr)
            {
                expressions.Add(expr);
            }
            public Expression<Func<T, object>> GetSelector()
            {
                // Create a new type in runtime that looks like a AnonymousType
                var str = $"<>f__AnonymousType0`{expressions.Count}";
                // Create type builder
                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                var modelBuilder = AppDomain.CurrentDomain
                                       .DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect)
                                       .DefineDynamicModule("module");
                var typeBuilder = modelBuilder.DefineType(str, TypeAttributes.Public | TypeAttributes.Class);
                var types = new Type[expressions.Count];
                var names = new string[expressions.Count];
                for (int i = 0; i < expressions.Count; i++)
                {
                    // Retrive passed properties
                    // TODO: current solutions doesn't work for class1->class2->Id
                    // you need to retrive names from all of nested expressions and then 
                    // create the nested Expression.Property in a assignments to fix this
                    var unExpr = expressions[i].Body as UnaryExpression;
                    var exp = unExpr == null ? expressions[i].Body as MemberExpression : unExpr.Operand as MemberExpression;
                    types[i] = exp.Type;
                    names[i] = exp.Member.Name;
                }
                // Defined generic parameters for custom type
                var genericParams = typeBuilder.DefineGenericParameters(types.Select((_, i) => $"PropType{i}").ToArray());
                for (int i = 0; i < types.Length; i++)
                {
                    typeBuilder.DefineField($"{names[i]}", genericParams[i], FieldAttributes.Public);
                }
                // Create generic type by passed properties
                var type = typeBuilder.CreateType();
                var genericType = type.MakeGenericType(types);
                ParameterExpression parameter = Expression.Parameter(typeof(T), "MyItem");
                var assignments = genericType.GetFields().Select((prop, i) => Expression.Bind(prop, Expression.Property(parameter, names[i])));
                return Expression.Lambda<Func<T, object>>(Expression.MemberInit(Expression.New(genericType.GetConstructors()[0]), assignments), parameter);
            }
        }
