        public static List<TreeNode> GetAllNodes(this TreeView _trv)
    {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode child in _trv.Nodes)
            {
                result.Add(child);
            }
            return result;
    }
 
