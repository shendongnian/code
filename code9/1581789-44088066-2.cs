    private static Expression<Func<SourceB, string>> 
        ConvertExpression(Expression<Func<SourceA, string>> expression)
    {
        var newParam = Expression.Parameter(typeof(SourceB), "src");
        var newExpression = Expression.Lambda<Func<SourceB, string>>(
            new ReplaceVisitor().Modify(expression.Body, newParam), newParam);
        return newExpression;
    }    
    
    class ReplaceVisitor : ExpressionVisitor
    {
        private ParameterExpression parameter;
        public Expression Modify(Expression expression, ParameterExpression parameter)
        {
            this.parameter = parameter;
            return Visit(expression);
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return Expression.Lambda<Func<SourceB, bool>>(
                Visit(node.Body), 
                Expression.Parameter(typeof(SourceB)));
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(SourceA))
            {
                return Expression.Property(parameter, nameof(SourceB.A));
            }
            throw new InvalidOperationException();
        }
    }   
