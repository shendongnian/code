    class RemoveConvertVisitor : ExpressionVisitor
    {
        protected override Expression VisitUnary(UnaryExpression node) =>
            node.NodeType == ExpressionType.Convert ? node.Operand : base.VisitUnary(node);
        protected override Expression VisitLambda<T>(Expression<T> node) =>
            Expression.Lambda(Visit(node.Body), node.Parameters);
    }
