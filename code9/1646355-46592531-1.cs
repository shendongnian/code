    public class RewritingVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression p = Expression.Parameter(typeof(ListItem)); // create new parameter which will be referenced later
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(Picture))
            {
                return p;
            }
            return node;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            var rewritten = Visit(node.Expression);
            if (rewritten == node.Expression) return node;
            if (node.Expression != null &&
                node.Expression.Type == typeof(Picture) &&
                rewritten.Type == typeof(ListItem))
            {
                if (node.Member.Name == "Id")
                {
                    return Expression.MakeMemberAccess(
                        rewritten,
                        typeof(ListItem).GetProperty("Id"));
                }
                else if (node.Member.Name == "FileName")
                {
                    return Expression.MakeIndex(
                        rewritten,
                        typeof(ListItem).GetProperty("Item"), // default indexer name
                        new[] { Expression.Constant("FileName") });
                }
            }
        }
    }
