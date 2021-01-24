    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        UpdateStatus("First Process started...");
        await Task.Delay(5000);
        UpdateStatus("First Process done!");
        await Task.Delay(5000);
        UpdateStatus("Second Process started...");
        await Task.Delay(5000);
        UpdateStatus("Second Process done!");
        await Task.Delay(5000);
        UpdateStatus("Third Process started...");
        await Task.Delay(5000);
        UpdateStatus("Third Process done!");
    }
    private void UpdateStatus(string message)
    {
        MainWindow.main.lblTest.Content = message;
    }
