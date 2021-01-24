    public static class ResursiveLogic
    {
        public static List<Tree> RemoveEmptyNodes(this List<Tree> tree)
        {
            if (tree==null)
            {
                return null;
            }
            if (tree.Count == 0)
            {
                return null;
            }
    
            foreach (var subtree in tree)
            {
                subtree.nodes = subtree.nodes.RemoveEmptyNodes();
            }
            return tree;
        }
    }
