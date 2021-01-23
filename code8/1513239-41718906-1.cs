    LoggingListBox.Loaded += (o, e) =>
        {
            Log.CollectionChanged += (oo, ee) => SelectLastEntry();
            SelectLastEntry();
        };
    ...
    private void SelectLastEntry()
    {
         LoggingListBox.SelectedIndex = LoggingListBox.Items.Count - 1;
    }
