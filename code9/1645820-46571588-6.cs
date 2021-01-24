    public class MyMemberExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.MemberType == MemberTypes.Property // is a property
                && node.Expression.NodeType == ExpressionType.Parameter // is from a parameter expression
                && Members.All(s => s != node.Member.Name)) // avoids duplicates
            {
                Members.Add(node.Member.Name);
            }
            return base.VisitMember(node);
        }
        public List<string> Members { get; set; } = new List<string>();
    }
