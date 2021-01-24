    public class ConverterVisitor : ExpressionVisitor
    {
        public ConverterVisitor(ParameterExpression original, Expression convertTo)
        {
            OriginalParameter = original;
            ConvertTo = convertTo;
        }
        public ParameterExpression OriginalParameter { get; }
        public Expression ConvertTo { get; }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (OriginalParameter == node)
            {
                return ConvertTo;
            }
            return base.VisitParameter(node);
        }
    }
