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
            TreeNode aNode = node.Nodes[i];
            DeleteUnselectedNodes(node);
            if (!aNode.Checked)
            {
                node.Nodes.Remove(aNode);
            }
        }
    }
