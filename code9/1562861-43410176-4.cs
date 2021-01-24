    private class ReplaceParameterExpressionVisitor : System.Linq.Expressions.ExpressionVisitor {
        private readonly ParameterExpression _toReplace;
        private readonly ParameterExpression _replaceWith;
        public ReplaceParameterExpressionVisitor(ParameterExpression toReplace, ParameterExpression replaceWith) {
            _toReplace = toReplace;
            _replaceWith = replaceWith;
        }            
        protected override Expression VisitParameter(ParameterExpression node) {
            if (node == _toReplace)
                // replace with new parameter and convert to the old parameter type
                return Expression.Convert(_replaceWith, _toReplace.Type);
            return base.VisitParameter(node);
        }
    }
