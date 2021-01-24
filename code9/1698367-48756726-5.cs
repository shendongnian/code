    class ParameterReplacer : ExpressionVisitor
    {
        private ParameterExpression _newParameter;
        public ParameterReplacer(ParameterExpression newParameter)
        {
            _newParameter = newParameter;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _newParameter; // forget about the old one, return the new
        }
    }
