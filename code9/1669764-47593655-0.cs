    private async void btnDoStuff_Click(object sender, RoutedEventArgs e)
    {
        btnDoStuff.IsEnabled = false;
        lblStatus.Content = "Doing Stuff";
        await Task.Delay(4000);
        lblStatus.Content = "Not doing anything";
        btnDoStuff.IsEnabled = true;
    }
