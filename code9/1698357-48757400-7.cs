    private void RadCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var items = radCheckedListBox.DataSource as IEnumerable<Peça>;
    
        if (items == null)
        {
            return;
        }
        var itemFromList = items
            .FirstOrDefault(i => i.Id == (int?)radCheckedListBox.SelectedItem?.Value);
    }
