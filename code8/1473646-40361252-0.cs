    // create linq expression
    System.Linq.Expressions.Expression<Func<Order, bool>> linqExpression =
        order => order.Items.Where(i => i.ProductId == prodId).Sum(i => i.Quantity) > 1;
    // transform linq expression into serializable expression tree
    Remote.Linq.Expressions.LambdaExpression serializableExpression =
        linqExpression.ToRemoteLinqExpression();
    // transform serializable expression tree back into linq expression
    System.Linq.Expressions.Expression<Func<Order, bool>> recreatedLinqExpression =
        serializableExpression.ToLinqExpression<Order, bool>();
