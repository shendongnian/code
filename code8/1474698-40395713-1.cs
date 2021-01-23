        public class ArgumentsVisitor : ExpressionVisitor
        {
            private readonly HashSet<MemberInfo> _all = new HashSet<MemberInfo>();
            public IEnumerable<MemberInfo> Arguments
            {
                get { return _all; }
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                _all.Add(node.Member);
                return base.VisitMember(node);
            }
        }
