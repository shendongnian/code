    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var t = Task.Run(() => DeadlockProducer(sender as MenuItem));
        var result = t.Result;
    }
    private async Task<int> DeadlockProducer(MenuItem sender)
    {
        await Task.Delay(1);
        Dispatcher.Invoke(() => sender.Header = "Life sucks");
        return 0;
    }
