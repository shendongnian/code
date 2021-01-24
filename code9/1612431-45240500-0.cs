    private void libHT_SelectedIndexChanged(object sender, EventArgs e)
    {
			libMonth.SelectedIndices.Clear();
			foreach (var index in libHT.SelectedIndices.Cast<int>())
			{
				libMonth.SelectedIndices.Add(index);
			}
    }
