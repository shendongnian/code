    private async void StartMacros(object sender, RoutedEventArgs e)
    {
        await AsyncTimerLoop();
    }
    public async Task AsyncTimerLoop()
    {
        for (int profileNumber = 1; profileNumber <= 10; profileNumber++)
        {
            OpenBrowser(profileNumber);
            await Task.Delay((10000));
        }
    }
