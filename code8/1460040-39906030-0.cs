    void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        treeView1.SelectedNode = e.Node;
      }
      if (e.Node.Level == 0) {
        e.Node.ContextMenuStrip = cms1;
      } else if (e.Node.Level == 1) {
        e.Node.ContextMenuStrip = cms2;
      } else  if (e.Node.Level == 2) {
        e.Node.ContextMenuStrip = cms3;
      }
    }
