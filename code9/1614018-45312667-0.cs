    public class WhereRemoveVisitor : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Where" && node.Method.DeclaringType == typeof(Queryable))
                return node.Arguments[0];
            else
                return base.VisitMethodCall(node);
        }
    }
