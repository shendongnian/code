    TreeNode findParent(string txt, TreeNode parent = null)
    {
       if (parent == null)
         parent = treeView1.Nodes[0];
       if (parent.Text == txt) return parent;
       foreach (TreeNode node in parent.Children)
       {
          var res = findParent(txt, node); //recursion
          if (res != null) return res;
       }
       return null;
    }
    
    foreach (DataGridViewRow row in dataGrid.Rows)
    {
        TreeNode parent = findParent(row.Cells[2].Value as string);
        var newNode = new TreeNode() { Text = row.Cells[0].Value as Text };
        if (parent != null)
           parent.Children.Add(newNode);
        else
           treeView1.Nodes.Add(newNode);
    }
