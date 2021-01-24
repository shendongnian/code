    public void remove(object sender, EventArgs e)
    {
        var itemsToDelete = new List<ListViewItem>();
        foreach (ListViewItem eachItem in listName.SelectedItems)
        {
            itemsToDelete.Add(eachItem);
        }
        foreach (ListViewItem eachItem in itemsToDelete)
        {
            listName.Items.Remove(eachItem);
        }
    }
