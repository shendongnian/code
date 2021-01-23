    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListView lv = sender as ListView;
        var removed = FindRadioButtonWithDataContext(lv, e.RemovedItems.FirstOrDefault());
        if (removed != null)
        {
            removed.IsChecked = false;
        }
        var added = FindRadioButtonWithDataContext(lv, e.AddedItems.FirstOrDefault());
        if (added != null)
        {
            added.IsChecked = true;
        }
    }
