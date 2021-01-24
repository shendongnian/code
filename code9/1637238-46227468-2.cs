    public class DataVisitor<T> : ExpressionVisitor
    {
        private readonly ConstantExpression _data;
    
        public DataVisitor(T dataItem)
        {
            _data = Expression.Constant(dataItem);
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
                return node.Type.IsAssignableFrom(typeof(T))
                        ? _data : base.VisitParameter(node);
        }
    }
