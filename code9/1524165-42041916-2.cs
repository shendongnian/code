        public class PredicateRewriter
        {
            public static Expression<Func<T, U>> Rewrite<T,U>(Expression<Func<T, U>> exp, //string newParamName
                ParameterExpression param)
            {
                //var param = Expression.Parameter(exp.Parameters[0].Type, newParamName);
                var newExpression = new PredicateRewriterVisitor(param).Visit(exp);
                return (Expression<Func<T, U>>)newExpression;
            }
