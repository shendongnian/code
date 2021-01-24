    private async void DialogPrimaryButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        await DisplayContentDialog();
    }
    private async Task DisplayContentDialog()
    {
        LoginDialog.PrimaryButtonClick += LoginDialog_PrimaryButtonClick;
        LoginDialog.SecondaryButtonClick += LoginDialog_SecondaryButtonClick;
        LoginDialog.CloseButtonClick += LoginDialog_CloseButtonClick;
        await LoginDialog.ShowAsync();
    }
    private void LoginDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        OutputText.Text = "Primary";
    }
    private void LoginDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        OutputText.Text = "Secondary";
    }
    private void LoginDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        OutputText.Text = "Cancel";
    }
