    private void SyncSelection(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.AddedItems)
        {
            secondListView.SelectedItems.Add(item);
        }
        foreach (var item in e.RemovedItems)
        {
            secondListView.SelectedItems.Remove(item);
        }
    }
