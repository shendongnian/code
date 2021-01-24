    public class AndSpecification<T> : Specification<T>
        where T : class
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            var paramExpr = Expression.Parameter(typeof(T));
            var andExpression = Expression.AndAlso(
                leftExpression.Body, rightExpression.Body);
            andExpression = (BinaryExpression) new ParameterReplacer(paramExpr).Visit(andExpression);
            
            return Expression.Lambda<Func<T, bool>>(andExpression, paramExpr);
        }
    }
    public class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(_parameter);
        }
        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
    }
