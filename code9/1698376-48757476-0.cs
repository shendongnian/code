    internal sealed class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _param;
        private ParameterReplacer(ParameterExpression param)
        {
            _param = param;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node.Type == _param.Type ?
                base.VisitParameter(_param) : // replace
                node; // ignore
        }
        public static T Replace<T>(ParameterExpression param, T exp) where T : Expression
        {
            return (T)new ParameterReplacer(param).Visit(exp);
        }
    }
