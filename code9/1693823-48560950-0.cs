    class ProjectionAnalyzer : ExpressionVisitor
    {
        private HashSet<MemberInfo> boundMembers = new HashSet<MemberInfo>();
        protected override MemberBinding VisitMemberBinding(MemberBinding node)
        {
            boundMembers.Add(node.Member);
            return base.VisitMemberBinding(node);
        }
        public IEnumerable<MemberInfo> BoundMembers => boundMembers;
    }
