    class ParameterBinder : ExpressionVisitor
    {
        readonly ParameterExpression parameter;
        readonly Expression replacement;
        public ParameterBinder(ParameterExpression parameter, Expression replacement)
        {
            this.parameter = parameter;
            this.replacement = replacement;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == parameter)
                return replacement;
            return base.VisitParameter(node);
        }
    }
