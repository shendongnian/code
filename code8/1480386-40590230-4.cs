    TreeNode[] treeNodes = treeView1.Nodes
                                    .Cast<TreeNode>()
                                    .Where(r => r.Tag == AccountsComboBox2.Text)
                                    .ToArray();
    foreach (TreeNode oldnode in treeNodes)
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
