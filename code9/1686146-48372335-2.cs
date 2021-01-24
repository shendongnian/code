    public static async void InitializeXboxGamer(TextBlock gamerTagTextBlock)
    {
        try
        {
            XboxLiveUser user = new XboxLiveUser();
            SignInResult result = await user.SignInSilentlyAsync(Window.Current.Dispatcher);
            if (result.Status == SignInStatus.UserInteractionRequired)
            {
                result = await user.SignInAsync(Window.Current.Dispatcher);
            }
            gamerTagTextBlock.Text = user.Gamertag;
            gamerTagTextBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        catch (Exception ex)
        {
            // TODO: log an error here
        }
    }
