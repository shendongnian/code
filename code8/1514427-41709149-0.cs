    private async void TbPassword_GotFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(tbUser.Text))
        {
            tbUser.Focus(FocusState.Programmatic);
            var md = new MessageDialog("Please specify a user first. ",
                "Enter UserName");
            md.Commands.Add(new UICommand("Okay")
            {
            });
            await md.ShowAsync();
        }
        else
        {
            preCheckUser();
        }
     }
