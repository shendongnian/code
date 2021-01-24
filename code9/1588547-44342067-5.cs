	List<int> indicies = AllIndicesOf(";", txtBxText.Text);
	try
	{
		if (indicies.Count > 0)
		{			
			int cursorPos = txtBxText.SelectionStart;
			var indicesBefore = indicies.Where(x => x < cursorPos);
			int beginIndex = indicesBefore.Count() > 0 ? indicesBefore.Last() : 0;
			int endIndex = indicies.Where(x => x > beginIndex).First();
			txtBxSelected.Text = txtBxText.Text.Substring(beginIndex, endIndex - beginIndex);
		}
	}
	catch { }
