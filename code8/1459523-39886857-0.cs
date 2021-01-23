    private void showDialog()
    {
        var dialog = new MessageDialog("You have unsaved changes. Continue?", "Warning");
        dialog.Commands.Add(new UICommand("OK", handler));
        dialog.Commands.Add(new UICommand("Cancel", handler));
        dialog.ShowAsync();
    }
    private void handler(IUICommand command)
    {
        System.Diagnostics.Debug.WriteLine($"The user clicked {command.Label}");
    }
