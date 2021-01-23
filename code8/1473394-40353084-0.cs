    private void Form1_Load(object sender, EventArgs e)
    {   
        foreach (DriveInfo drv in DriveInfo.GetDrives())
        {
            if (drv.IsReady)
            {
                TreeNode t2 = new TreeNode();
                t2.Text = drv.Name;
                t2.Nodes.Add("make this not empty to show a result");
                treeView.Nodes.Add(t2);
    
                treeView.ExpandAll();
            }
        }
    }
