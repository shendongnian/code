    public class MyMemberExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.MemberType == MemberTypes.Property
                && Members.All(s => s != node.Member.Name))
            {
                Members.Add(node.Member.Name);
            }
            return base.VisitMember(node);
        }
        public List<string> Members { get; set; } = new List<string>();
    }
