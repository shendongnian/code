    private void RadCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var items = radCheckedListBox.DataSource as IEnumerable<Peça>;
    
        if (items == null)
        {
            return;
        }
        var selectedItem = radCheckedListBox.SelectedItem as Peça;
        var itemFromList = items.FirstOrDefault(i => i.Id == selectedItem?.Id);
    }
