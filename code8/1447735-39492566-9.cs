    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        var node = treeView1.GetNodeAt(e.X, e.Y);
        var hti = treeView1.HitTest(e.Location);
        if (node == null)
            return;
        treeView1.BeginInvoke(new Action(() => treeView1.SelectedNode = node));
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            node.Toggle();
        }
        else if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            if (hti.Location != TreeViewHitTestLocations.PlusMinus)
                node.Toggle();
        }
    }
