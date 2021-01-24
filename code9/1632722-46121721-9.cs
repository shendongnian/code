    public static class QueryTreeHelper
    {
        public static QueryTreeNode Leaf(string property, int value)
        {
            return new QueryTreeNode
            {
                Type = NodeType.Leaf,
                Leaf = new QueryTreeLeaf
                {
                    PropertyName = property,
                    Value = value.ToString()
                }
            };
        }
        public static QueryTreeNode Branch(QueryTreeNode left, QueryTreeNode right)
        {
            return new QueryTreeNode
            {
                Type = NodeType.Branch,
                Branch = new QueryTreeBranch
                {
                    Left = left,
                    Right = right
                }
            };
        }
    }
