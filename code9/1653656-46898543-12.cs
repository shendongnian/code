    private List<string> ls = new List<string>();
    private void Add_Click(object sender, EventArgs e)
    {
        string add = textBox1.Text;
        // Avoid adding same item twice
        if (!ls.Contains(add)) {
            ls.Add(add);
            RefreshListBox();
        }
    }
    private void Delete_Click(object sender, EventArgs e)
    {
        // Delete the selected items.
        // Delete in reverse order, otherwise the indices of not yet deleted items will change
        // and not reflect the indices returned by SelectedIndices collection anymore.
        for (int i = List.SelectedIndices.Count - 1; i >= 0; i--) { 
            ls.RemoveAt(List.SelectedIndices[i]);
        }
        RefreshListBox();
    }
    private void RefreshListBox()
    {
        List.DataSource = null;
        List.DataSource = ls;
    }
