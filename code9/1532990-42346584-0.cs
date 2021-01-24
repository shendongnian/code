    private void trvP_AfterCheck(object sender, TreeViewEventArgs e)
    {
            if(e.Node.Tag.Equals("Root"))
            {
                var nodes = e.Node.TreeView.GetAllNodes();
                foreach (TreeNode node in nodes)
                {
                    if (node == e.Node) continue; // don't do it for root again
                    node.Checked = e.Node.Checked;
                }
            }
    }
