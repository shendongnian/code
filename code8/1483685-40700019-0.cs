    internal sealed class ParameterReplaceVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _searched;
        private readonly Expression _replaced;
        public ParameterReplaceVisitor(ParameterExpression searched, Expression replaced)
        {
            if (searched == null)
                throw new ArgumentNullException(nameof(searched));
            if (replaced == null)
                throw new ArgumentNullException(nameof(replaced));
            _searched = searched;
            _replaced = replaced;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _searched)
                return _replaced;
            return base.VisitParameter(node);
        }
    }
