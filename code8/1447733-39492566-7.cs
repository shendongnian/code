        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
                treeView1.BeginInvoke(new Action(() => { treeView1.SelectedNode.Toggle(); }));
            }
        }
