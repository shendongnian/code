    public static Expression<Func<T, bool>> CombineWithOr<T>(params Expression<Func<T, bool>>[] filters)
    {
        var first = filters.First();
        var param = first.Parameters.First();
        var body = first.Body;
                
        foreach(var other in filters.Skip(1))
        {
            var replacer = new ReplaceParameter
            {
                OriginalParameter = other.Parameters.First(),
                NewParameter = param
            };
            // We need to replace the original expression parameter with the result parameter
            body = Expression.Or(body, replacer.Visit(other.Body));
        }
    
        return Expression.Lambda<Func<T, bool>>(
            body,
            param
        );
    }
    class ReplaceParameter : ExpressionVisitor
    {
        public Expression OriginalParameter { get; set; }
        public Expression NewParameter { get; set; }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == this.OriginalParameter ? this.NewParameter : base.VisitParameter(node);
        }
    }
