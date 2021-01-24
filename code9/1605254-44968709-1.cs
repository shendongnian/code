    private void btn_GetSelected_Click(object sender, EventArgs e)
	{
		string selectedNodes = "";
		foreach (TreeNode tn in this.treeViewMenu.Nodes)
		{
			GetSelectedNodesByTag(tn, ref selectedNodes);
		}
		MessageBox.Show(selectedNodes, "Selected Nodes");
	}
	private void GetSelectedNodesByTag(TreeNode Node, ref string SelectedNodes)
	{
		if ((bool)Node.Tag == true)
		{
			if (SelectedNodes != "") SelectedNodes += "\n";
			SelectedNodes += Node.FullPath;
		}
		foreach (TreeNode subNode in Node.Nodes)
		{
			GetSelectedNodesByTag(subNode, ref SelectedNodes);
		}
	}
