    public class ArgumentExtractor : System.Linq.Expressions.ExpressionVisitor
    {
        private Dictionary<string, object> arguments;
        public IDictionary<string, object> Arguments => arguments;
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            arguments = node.Arguments
                .Select(a =>
                {
                    var memeber = a as MemberExpression;
                    if (memeber == null)
                        return null;
                    var name = memeber.Member.Name;
                    var container = (memeber.Expression as ConstantExpression)?.Value;
                    var value = container.GetType().GetField(name).GetValue(container);
                    return new {name, value};
                })
                .Where(x => x != null)
                .ToDictionary(x => x.name, x => x.value);
            return base.VisitMethodCall(node);
        }
    }
