    private void SyncSelection(object sender, SelectionChangedEventArgs e)
    {
        ListView listViewToAdd = ReferenceEquals(sender, firstListView) ? secondListView : firstListView;
        foreach (var item in e.AddedItems)
        {
            if (!listViewToAdd.SelectedItems.Contains(item))
            {
                listViewToAdd.SelectedItems.Add(item);
            }
        }
        foreach (var item in e.RemovedItems)
        {
            listViewToAdd.SelectedItems.Remove(item);
        }
    }
