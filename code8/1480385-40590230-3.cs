    TreeNode[] treeNodes = treeView1.Nodes
                                    .Cast<TreeNode>()
                                    .Where(r => r.Text == AccountsComboBox2.Text)
                                    .ToArray();
    foreach (TreeNode oldnode in nodes)
     {
        if (oldnode.Parent == null)
        {
            treeView1.Nodes.Remove(oldnode);
        }
        else
        {
            oldnode.Parent.Nodes.Remove(oldnode);
        }
    }
