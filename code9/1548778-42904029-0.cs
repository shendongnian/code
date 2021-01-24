    public class TypeReplacer : ExpressionVisitor
    {
        public readonly Dictionary<Type, Type> Conversions = new Dictionary<Type, Type>();
        private readonly Dictionary<Expression, Expression> ParameterConversions = new Dictionary<Expression, Expression>();
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
                    node = Expression.Lambda(lambda.Body, parameters);
                }
                return base.Visit(node);
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
                switch (node.Member.MemberType)
                {
                    case MemberTypes.Field:
                        {
                            var field = (FieldInfo)node.Member;
                            BindingFlags bf = (field.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic) |
                                (field.IsStatic ? BindingFlags.Static : BindingFlags.Instance);
                            var field2 = to.GetField(node.Member.Name, bf);
                            return Expression.MakeMemberAccess(expression, field2);
                        }
                    case MemberTypes.Property:
                        {
                            var prop = (PropertyInfo)node.Member;
                            var method = prop.GetMethod ?? prop.SetMethod;
                            BindingFlags bf = (method.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic) |
                                (method.IsStatic ? BindingFlags.Static : BindingFlags.Instance);
                            var indexes = prop.GetIndexParameters();
                            var types = Array.ConvertAll(indexes, x => x.ParameterType);
                            var property2 = to.GetProperty(node.Member.Name, bf, null, prop.PropertyType, types, null);
                            return Expression.MakeMemberAccess(expression, property2);
                        }
                    case MemberTypes.Method:
                        {
                            var method = (MethodInfo)node.Member;
                            BindingFlags bf = (method.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic) |
                                (method.IsStatic ? BindingFlags.Static : BindingFlags.Instance);
                            var parameters = method.GetParameters();
                            var types = Array.ConvertAll(parameters, x => x.ParameterType);
                            var method2 = to.GetMethod(node.Member.Name, bf, null, types, null);
                            return Expression.MakeMemberAccess(expression, method2);
                        }
                    default:
                        throw new NotSupportedException(node.Member.MemberType.ToString());
                }
            }
            return base.VisitMember(node);
        }
    }
