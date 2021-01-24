    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var task = Dispatcher.InvokeAsync(() => sw.Stop(), DispatcherPriority.ApplicationIdle);
        populate_data();
        await task;
        ElapsedToIdle = sw.Elapsed;
    }
