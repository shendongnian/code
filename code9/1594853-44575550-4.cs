    private async void DialogPrimaryButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        await DisplayContentDialog();
    }
    private async Task DisplayContentDialog()
    {
        ContentDialogResult result = await LoginDialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            OutputText.Text = "Primary";
            // User Pressed Primary key
        }
        else if (result == ContentDialogResult.Secondary)
        {
            OutputText.Text = "Secondary";
            // User Pressed Secondary key
        }
        else
        {
            OutputText.Text = "Cancel";
            // User pressed Cancel, ESC, or the back arrow.
        }
    }
