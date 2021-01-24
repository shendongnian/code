    private void txtbox1_TextChanged(object sender, EventArgs e)
	{
		foreach (TreeNode tn in this.treeViewMenu.Nodes)
		{
			SetColor(tn);
		}
	}
    private void SetColor(TreeNode Node)
	{
		if (Node.Text.Contains(this.txtbox1.Text))
		{
			Node.BackColor = System.Drawing.Color.Blue;
			Node.ForeColor = System.Drawing.Color.White;
			Node.Tag = true; //for later to find out which Nodes are "selected"
		}
		else
		{
			Node.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Window);
			Node.ForeColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.WindowText);
			Node.Tag = false;
		}
		foreach (TreeNode subNode in Node.Nodes)
		{
			SetColor(subNode);
		}
	}
