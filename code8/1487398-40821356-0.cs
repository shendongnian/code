    Expression<Func<int, int>> c = (int a) => a * (a + 3);
    var d = Extensions.Splice<Func<int, int>>((x) => 2 + c.Embed(3 + x));
    // d is now x => (2 + ((3 + x) * ((3 + x) + 3))) expression
----------
    public static class Extensions
    {
        public static T Embed<T>(this Expression<Func<T>> exp) { throw new Exception("Should not be executed"); }
        public static T Embed<A, T>(this Expression<Func<A, T>> exp, A a) { throw new Exception("Should not be executed"); }
        public static T Embed<A, B, T>(this Expression<Func<A, B, T>> exp, A a, B b) { throw new Exception("Should not be executed"); }
        public static T Embed<A, B, C, T>(this Expression<Func<A, B, C, T>> exp, A a, B b, C c) { throw new Exception("Should not be executed"); }
        public static T Embed<A, B, C, D, T>(this Expression<Func<A, B, C, D, T>> exp, A a, B b, C c) { throw new Exception("Should not be executed"); }
        public static Expression<T> Splice<T>(Expression<T> exp)
        {
            return new SplicingVisitor().Visit(exp) as Expression<T>;
        }
        class SplicingVisitor : ExpressionVisitor
        {
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method.Name == "Embed")
                {
                    var mem = node.Arguments[0] as MemberExpression;
                    
                    var getterLambda = Expression.Lambda<Func<object>>(mem, new ParameterExpression[0]);
                    var lam = getterLambda.Compile().DynamicInvoke() as LambdaExpression;
                    var parameterMapping = lam.Parameters.Select((p, index) => new
                    {
                        FormalParameter = p,
                        ActualParameter = node.Arguments[index+1]
                    }).ToDictionary(o => o.FormalParameter, o => o.ActualParameter);
                    return new ParameterReplacerVisitor(parameterMapping).Visit(lam.Body);
                }
                return base.VisitMethodCall(node);
            }
        }
        public class ParameterReplacerVisitor : ExpressionVisitor
        {
            private Dictionary<ParameterExpression, Expression> parameterMapping;
            public ParameterReplacerVisitor(Dictionary<ParameterExpression, Expression> parameterMapping)
            {
                this.parameterMapping = parameterMapping;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if(parameterMapping.ContainsKey(node))
                {
                    return parameterMapping[node];
                }
                return base.VisitParameter(node);
            }
        }
    }
