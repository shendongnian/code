    public class UiTransactionUpdate : BaseRuleMessage<UiTransactionUpdate>
    {
        public override Func<UiTransactionUpdate, bool> CompileRule(Rule r, UiTransactionUpdate msg)
        {
            var expression = Expression.Parameter(typeof(UiTransactionUpdate));
            Expression expr = BuildExpr(r, expression, msg);
            return Expression.Lambda<Func<UiTransactionUpdate, bool>>(expr, expression).Compile();
        }
        public Guid TransactionId { get; set; }
        public Guid GroupId { get; set; }
        public decimal StatusValue { get; set; }
        private Expression BuildExpr(Rule rule, ParameterExpression parameterExpression, UiTransactionUpdate message)
        {
            var transactionIdProperty = Expression.Property(parameterExpression, "TransactionId");
            var value = Expression.Constant(rule.TransactionId);
            return Expression.Equal(transactionIdProperty, value);
        }
    }
