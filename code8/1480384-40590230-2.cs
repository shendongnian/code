    TreeNode node = this.treeView1.Nodes
                                  .Cast<TreeNode>()
                                  .FirstOrDefault(x => x.Name == AccountsComboBox2.Text);
    if (node != null)
    {
        if (node.Parent == null)
        {
            treeView1.Nodes.Remove(node);
        }
        else
        {
            node.Parent.Nodes.Remove(node);
        }
    }
