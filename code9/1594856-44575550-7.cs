    private async void DialogPrimaryButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        await DisplayContentDialog();
    }
    private async Task DisplayContentDialog()
    {
        XAMLButton.Click += XAMLButton_Click;
        LoginDialog.PrimaryButtonClick += LoginDialog_PrimaryButtonClick;
        LoginDialog.SecondaryButtonClick += LoginDialog_SecondaryButtonClick;
        LoginDialog.CloseButtonClick += LoginDialog_CloseButtonClick;
        await LoginDialog.ShowAsync();
    }
    //For Primary Button inside the ContentDialog
    private void LoginDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        OutputText.Text = "Primary";
    }
    //For Secondary Button inside the ContentDialog
    private void LoginDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        OutputText.Text = "Secondary";
    }
    //For Cancel Buttons inside the ContentDialog
    private void LoginDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        OutputText.Text = "Cancel";
    }
    //For custom Buttons inside the ContentDialog
    private void XAMLButton_Click(object sender, RoutedEventArgs e)
    {
        OutputText.Text = "XAML Button";
        LoginDialog.Hide();
    }
