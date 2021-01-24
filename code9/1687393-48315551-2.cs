    private void buttonShowSelected_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < treeViewFilter.Nodes.Count; i++)
        {
            DeleteUnselectedNodes(treeViewFilter.Nodes[i]);
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
            if (parent != null)//If it isn't root
            {
                parent.Nodes.Remove(node);
            }
            else
            {
                treeViewFilter.Nodes.Remove(node);
            }
        }
    }
