    public void VideosListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e?.AddedItems?.Count > 0)
        {
            var fileDisplayName = e.AddedItems.FirstOrDefault() as string;
            if (!string.IsNullOrEmpty(fileDisplayName))
                SelectVideo(fileDisplayName);
        }
    }
