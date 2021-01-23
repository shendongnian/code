        private class ExchangeParametersVisitor : ExpressionVisitor
        {
            public ParameterExpression Parameter { get; set; }
            public Expression Value { get; set; }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node == Parameter)
                {
                    return Value;
                }
                return node;
            }
        }
