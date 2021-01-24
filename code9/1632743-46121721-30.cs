    public class QueryTreeNode
    {
        // Branch data (should be null for leaf)
        public QueryTreeNode LeftBranch { get; set; }
        public QueryTreeNode RightBranch { get; set; }
        // Leaf data (should be null for branch)
        public string PropertyName { get; set; }
        public string Value { get; set; }
    }
