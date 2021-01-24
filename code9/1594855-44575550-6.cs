    private async void DialogPrimaryButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        await DisplayContentDialog();
    }
    private async Task DisplayContentDialog()
    {
        ContentDialogResult result = await LoginDialog.ShowAsync();
        //For Primary, Secondary and Cancel Buttons inside the ContentDialog
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
    //For custom Buttons inside the ContentDialog
    //Use Button Click event for the custom Buttons inside the ContentDialog
    private void XAMLButton_Click(object sender, RoutedEventArgs e)
    {
        OutputText.Text = "XAML Button";
        LoginDialog.Hide();
    }
