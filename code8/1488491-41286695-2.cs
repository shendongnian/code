    internal class SelectStatementVisitor : TSqlFragmentVisitor
    {
        public IList<SelectStatement> Statements { get; private set; }
        public SelectStatementVisitor()
        {
            Statements = new List<SelectStatement>();
        }
        public override void ExplicitVisit(SelectStatement node)
        {
            Statements.Add(node);
        }
    }
    internal class BooleanComparisonVisitor : TSqlFragmentVisitor
    {
        public IList<BooleanComparisonExpression> Statements { get; private set; }
        public BooleanComparisonVisitor()
        {
            Statements = new List<BooleanComparisonExpression>();
        }
        public override void ExplicitVisit(BooleanComparisonExpression node)
        {
            Statements.Add(node);
        }
    }
