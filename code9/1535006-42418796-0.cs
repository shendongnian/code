    var selectedItem = listView.SelectedItem as ErrorLog;
    if (selectedItem != null &&
        string.IsNullOrWhitespace(selectedItem.Status) &&
        File.Exists(selectedItem.Log))
    {
        string filename = selectedItem.Log;
    }
    // else it is a status log entry or something else doesn't match up
