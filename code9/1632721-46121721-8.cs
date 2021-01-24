    public class QueryTreeBranch
    {
        public QueryTreeNode Left { get; set; }
        public QueryTreeNode Right { get; set; }
        public ExpressionCombine Combinor { get; set; }
    }
    public class QueryTreeLeaf
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
    }
    public enum ExpressionCombine
    {
        And = 0, Or
    }
