    public static class TreeViewExtensions
    {
        public static List<TreeNode> Ancestors(this TreeNode node)
        {
            return AncestorsInternal(node).Reverse().ToList();
        }
        private static IEnumerable<TreeNode> AncestorsInternal(TreeNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
                yield return node;
            }
        }
    }
