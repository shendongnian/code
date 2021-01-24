    internal class PropertySearchVisitor : ExpressionVisitor
    {
        private List<MemberInfo> properties = new List<MemberInfo>();
        public IEnumerable<MemberInfo> Properties => properties;
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node?.Member?.MemberType == MemberTypes.Property)
                properties.Add(node.Member);
            return base.VisitMember(node);
        }
    }
