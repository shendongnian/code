    public class ReplaceExpressionVisitor
        : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;
        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }
        public override Expression Visit(Expression node)
        {
            if (node == _oldValue)
                return _newValue;
            return base.Visit(node);
        }
    }
    
    // Elsewhere...
    public Expression BuildExpression(Expression parameter, string value)
    {
        Expression<Predicate<Object>> e1 = a => a.ToString() == value;
        return (new ReplaceExpressionVisitor(e1.Parameters[0], parameter)).Visit(e1.Body);
    }
