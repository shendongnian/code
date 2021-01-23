    internal class NamedTableReferenceVisitor : TSqlFragmentVisitor
    {
        public IList<NamedTableReference> Statements { get; private set; }
        public NamedTableReferenceVisitor()
        {
            Statements = new List<NamedTableReference>();
        }
        public override void ExplicitVisit(NamedTableReference node)
        {
            Statements.Add(node);
        }
    }
