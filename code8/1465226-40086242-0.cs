    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Node.Name == "root")
        {
            CustomerFrm childForm = new CustomerFrm();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
