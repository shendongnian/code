    public static class Express
    {
        /// <summary>
        /// Replace .Compile() calls to lambdas with the lambdas themselves.
        /// </summary>
        public static Expression<TDelegate> Uncompile<TDelegate>(Expression<TDelegate> lambda)
        => (Expression<TDelegate>)UncompileVisitor.Singleton.Visit(lambda);
        /// <summary>
        /// Evaluate an expression to a value.
        /// </summary>
        private static object GetValue(Expression x)
        {
            switch (x.NodeType)
            {
                case ExpressionType.Constant:
                    return ((ConstantExpression)x).Value;
                case ExpressionType.MemberAccess:
                    var xMember = (MemberExpression)x;
                    var instance = xMember.Expression == null ? null : GetValue(xMember.Expression);
                    switch (xMember.Member.MemberType)
                    {
                        case MemberTypes.Field:
                            return ((FieldInfo)xMember.Member).GetValue(instance);
                        case MemberTypes.Property:
                            return ((PropertyInfo)xMember.Member).GetValue(instance);
                        default:
                            throw new Exception(xMember.Member.MemberType + "???");
                    }
                default:
                    // NOTE: it would be easy to compile and invoke the expression, but it's intentionally not done. Callers can always pre-evaluate and pass a member of a closure.
                    throw new NotSupportedException("Only constant, field or property supported.");
            }
        }
        private sealed class UncompileVisitor : ExpressionVisitor
        {
            public static UncompileVisitor Singleton { get; } = new UncompileVisitor();
            private UncompileVisitor() { }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method.Name != "Compile" || node.Arguments.Count != 0 || node.Object == null || !typeof(LambdaExpression).IsAssignableFrom(node.Object.Type))
                    return base.VisitMethodCall(node);
                var lambda = (LambdaExpression)GetValue(node.Object);
                return lambda;
                // alternatively recurse on the lambda if it possibly could contain .Compile()s
                // return Visit(lambda); // recurse on the lambda
            }
        }
    }
