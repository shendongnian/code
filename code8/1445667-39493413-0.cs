    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        TreeNode node = null;
        node = treeView1.GetNodeAt(e.X, e.Y);
        var hti = treeView1.HitTest(e.Location);
        if (e.Button != MouseButtons.Right ||
            hti.Location == TreeViewHitTestLocations.PlusMinus ||
            node == null)
        {
            return;
        }
        treeView1.SelectedNode = node;
        contextMenuStrip1.Show(treeView1, node.Bounds.Left, node.Bounds.Bottom);
    }
