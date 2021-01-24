    private TreeNode SearchTreeView(string p_sSearchTerm, TreeNodeCollection p_Nodes)
    {
        foreach (TreeNode node in p_Nodes)
        {
            if (node.Text == p_sSearchTerm)
                return node;
            if (node.Nodes.Count > 0)
            {
                TreeNode child = SearchTreeView(p_sSearchTerm, node.Nodes);
                if (child != null) return child;
            }
        }
        return null;
    }
