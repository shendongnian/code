    private void SetChecked(TreeNode Node)
	{
		if (Node.Text.Contains(this.txtbox1.Text))
		{
			Node.Checked = true;
		}
		else
		{
			Node.Checked = false;
		}
		foreach (TreeNode subNode in Node.Nodes)
		{
			SetChecked(subNode);
		}
	}
