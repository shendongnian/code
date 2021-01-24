    public class AddTakeVisitor : ExpressionVisitor
    {
        private readonly int takeAmount;
        private bool firstEntry = true;
        public AddTakeVisitor(int takeAmount)
        {
            this.takeAmount = takeAmount;
        }
        public override Expression Visit(Expression node)
        {
            if (!firstEntry)
                return base.Visit(node);
            firstEntry = false;
            var methodCallExpression = node as MethodCallExpression;
            if (methodCallExpression == null)
                return base.Visit(node);
            if (methodCallExpression.Method.Name == "Take")
                return base.Visit(node);
            var elementType = node.Type.GetGenericArguments();
            var methodInfo = typeof(Queryable)
                .GetMethod("Take", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod(elementType.First());
            return Expression.Call(methodInfo, node, Expression.Constant(takeAmount));
        }
    }
    
