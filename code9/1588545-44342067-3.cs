	List<int> indicies = AllIndicesOf(";", txtBxText.Text);
	try
	{
		if (indicies.Count > 0)
		{
			int cursorPos = txtBxText.SelectionStart;
			int nextIndex = indicies.Where(x => x > cursorPos).First();
			txtBxSelected.Text = txtBxText.Text.Substring(cursorPos, nextIndex - cursorPos);
		}
	}
	catch { }
