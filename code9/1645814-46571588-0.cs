    class MemberExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            Members.Add(node.Member.Name);
            return base.VisitMember(node);
        }
        public List<string> Members { get; set; } = new List<string>();
    }
