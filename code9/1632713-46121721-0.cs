    public class QueryTreeNode
    {
        public NodeType Type { get; set; }
        public QueryTreeBranch Branch { get; set; }
        public QueryTreeLeaf Leaf { get; set; }
    }
    public enum NodeType
    {
        Branch, Leaf
    }
