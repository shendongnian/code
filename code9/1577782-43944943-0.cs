    internal class Finder : ExpressionVisitor {
        private readonly string toFind;
        public Finder(string toFind) {
            this.toFind = toFind;
        }
        public bool IsFound { get; private set; }
        protected override Expression VisitMember(MemberExpression node) {
            IsFound |= node.Member.MemberType == MemberTypes.Property && node.Member.Name == toFind;
            return base.VisitMember(node);
        }
    }
