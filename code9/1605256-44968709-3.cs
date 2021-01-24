    private void GetCheckedNodes(TreeNode Node, ref string SelectedNodes)
	{
		if (Node.Checked)
		{
			if (SelectedNodes != "") SelectedNodes += "\n";
			SelectedNodes += Node.FullPath;
		}
			
		foreach (TreeNode subNode in Node.Nodes)
		{
			GetCheckedNodes(subNode, ref SelectedNodes);
		}
	}
