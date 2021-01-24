    public class ReplaceVisitor<T> : ExpressionVisitor
    {
        private readonly MemberExpression _replacement;
        public ReplaceVisitor(MemberExpression replacement)
        {
            _replacement = replacement;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node.Type.IsAssignableFrom(typeof(T))
                    ? _replacement : base.VisitParameter(node);
        }
    }
