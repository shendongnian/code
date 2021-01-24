    void treeView1_KeyDown(object sender, KeyEventArgs e) {
      if (e.Control && e.KeyCode == Keys.Down) {
        TreeNode tn = treeView1.SelectedNode;
        if (tn != null) {
          if (tn.Parent == null) {
            if (tn.Index < treeView1.Nodes.Count - 1) {
              treeView1.SelectedNode = treeView1.Nodes[tn.Index + 1];
            }
          } else {
            if (tn.Index < tn.Parent.Nodes.Count - 1) {
              treeView1.SelectedNode = tn.Parent.Nodes[tn.Index + 1];
            }
          }
        e.Handled = true;
        }
      }
    }
