    private void optest_Click(object sender, RoutedEventArgs e)
    {
        string message = "message test";
        string title = "title test";
        List<UICommand> commands = new List<UICommand>();
        var decline = new UICommand("No, I Decline", async command =>
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                (Window.Current.Content as Frame).Navigate(typeof(LoginPage));
            });
        });
        commands.Add(decline);
        ShowDialogue(message, title, commands); 
    }
