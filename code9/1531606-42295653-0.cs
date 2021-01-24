    private TreeNode SearchTreeView(string p_sSearchTerm, TreeNodeCollection p_Nodes)
    {
        foreach (TreeNode node in p_Nodes)
        {
            if (node.Text == p_sSearchTerm)
            {
                return node;
            }
            if (node.Nodes.Count > 0)
            {
                var result = SearchTreeView(p_sSearchTerm, node.Nodes);
                if (result != null)
                {
                    return result;
                }
            }
        }
        return null;
    }
