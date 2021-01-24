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
                // We will create a new type in runtime that looks like a AnonymousType
                var str = $"<>f__AnonymousType0`{expressions.Count}";
                // Create type builder
                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                var modelBuilder = AppDomain.CurrentDomain
                                            .DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect)
                                            .DefineDynamicModule("module");
                var typeBuilder = modelBuilder.DefineType(str, TypeAttributes.Public | TypeAttributes.Class);
                var types = new Type[expressions.Count];
                var names = new List<string>[expressions.Count];
                for (int i = 0; i < expressions.Count; i++)
                {
                    // Retrive passed properties
                    var unExpr = expressions[i].Body as UnaryExpression;
                    var exp = unExpr == null ? expressions[i].Body as MemberExpression : unExpr.Operand as MemberExpression;
                    types[i] = exp.Type;
                    // Retrive a nested properties
                    names[i] = GetAllNestedMembersName(exp);
                }
                // Defined generic parameters for custom type
                var genericParams = typeBuilder.DefineGenericParameters(types.Select((_, i) => $"PropType{i}").ToArray());
                for (int i = 0; i < types.Length; i++)
                {
                    typeBuilder.DefineField($"{string.Join("_", names[i])}", genericParams[i], FieldAttributes.Public);
                }
                // Create generic type by passed properties
                var type = typeBuilder.CreateType();
                var genericType = type.MakeGenericType(types);
                ParameterExpression parameter = Expression.Parameter(typeof(T), "MyItem");
                // Create nested properties
                var assignments = genericType.GetFields().Select((prop, i) => Expression.Bind(prop, GetAllNestedMembers(parameter, names[i])));
                return Expression.Lambda<Func<T, object>>(Expression.MemberInit(Expression.New(genericType.GetConstructors()[0]), assignments), parameter);
            }
            private Expression GetAllNestedMembers(Expression parameter, List<string> properties)
            {
                Expression expression = parameter;
                for (int i = 0; i < properties.Count; ++i)
                {
                    expression = Expression.Property(expression, properties[i]);
                }
                return expression;
            }
            private List<string> GetAllNestedMembersName(Expression arg)
            {
                var result = new List<string>();
                var expression = arg as MemberExpression;
                while (expression != null && expression.NodeType != ExpressionType.Parameter)
                {
                    result.Insert(0, expression.Member.Name);
                    expression = expression.Expression as MemberExpression;
                }
                return result;
            }
        }
