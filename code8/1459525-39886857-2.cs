    private async Task displayDialogAsync()
    {
        var dialog = new MyDialog();  // Whatever you named your ContentDialog subclass
        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            // User clicked OK
        }
        else if (result == ContentDialogResult.Secondary)
        {
            // User clicked Cancel
        }
    }
