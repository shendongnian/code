    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (panel1.Controls.Count == 0)
        {
            panel1.Controls.Add(new TreeView());
            panel1.Controls[0].Dock = DockStyle.Fill;
        }
        TreeView tv = panel1.Controls[0] as TreeView;
        if (tv != null)
        {
            tv.Nodes.Clear();
            // option 1 deep copy:
            TreeNode tc = (TreeNode)e.Node.Clone();
            tv.Nodes.Add(tc);
            // option 2 shallow copy, 1 level
            TreeNode tn =  tv.Nodes.Add(e.Node.Text);
            foreach (TreeNode cn in e.Node.Nodes)
                tn.Nodes.Add(cn.Text);
        }
        tv.ExpandAll();
    }
