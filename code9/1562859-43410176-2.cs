    private class ReplaceParameterExpressionVisitor : System.Linq.Expressions.ExpressionVisitor {
        private readonly ParameterExpression _toReplace;
        private readonly ParameterExpression _replaceWith;
        public ReplaceParameterExpressionVisitor(ParameterExpression toReplace, ParameterExpression replaceWith) {
            _toReplace = toReplace;
            _replaceWith = replaceWith;
        }            
        protected override Expression VisitMember(MemberExpression node) {                
            if (node.Expression == _toReplace) {
                // if we access some member of our parameter
                // replace that with new parameter + Convert to target type
                // because new parameter is object
                return Expression.MakeMemberAccess(Expression.Convert(_replaceWith, _toReplace.Type), node.Member);
            }
            return base.VisitMember(node);
        }
        protected override Expression VisitParameter(ParameterExpression node) {
            // just replace
            if (node == _toReplace)
                return _replaceWith;
            return base.VisitParameter(node);
        }
    }
