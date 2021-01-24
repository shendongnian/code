    private void buttonShowSelected_Click(object sender, EventArgs e)
    {
        var rootNodes = new List<TreeNode>(treeViewFilter.Nodes.Cast<TreeNode>());
        foreach (var treeNode in rootNodes)
        {
            DeleteUnselectedNodes(treeNode);
        }
    }
    private void DeleteUnselectedNodes(TreeNode node)
    {
        for (int i = 0; i < node.Nodes.Count; i++)
        {
            DeleteUnselectedNodes(node.Nodes[i]);
        }
            
        if (!node.Checked)
        {
            var parent = node.Parent;
            if (parent != null) //If it isn't root
            {
                parent.Nodes.Remove(node);
            }
            else
            {
                treeViewFilter.Nodes.Remove(node);
            }
        }
    }
