    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListView lv = sender as ListView;
        var removed = FindRadioButtonWithDataContext(lv, e.RemovedItems.FirstOrDefault() as Data);
        if (removed != null)
        {
            removed.IsChecked = false;
        }
        var added = FindRadioButtonWithDataContext(lv, e.AddedItems.FirstOrDefault() as Data);
        if (added != null)
        {
            added.IsChecked = true;
        }
    }
