    private void buttonShowSelected_Click(object sender, EventArgs e)
    {
        var nodes = new List<TreeNode>(treeViewFilter.Nodes.Cast<TreeNode>());
        foreach (var treeNode in nodes)
        {
            DeleteUnselectedNodes(treeNode);
        }
    }
    private void DeleteUnselectedNodes(TreeNode node)
    {
        var nodes = new List<TreeNode>(node.Nodes.Cast<TreeNode>());
        foreach (var treeNode in nodes)
        {
            DeleteUnselectedNodes(treeNode);
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
