    private void Read_All_Button_Click(object sender, RoutedEventArgs e)
    {
        // Start timedout task that will send all necessary commands
        CancellationTokenSource cts = new CancellationTokenSource(10000);
        Task.Run(() =>
        {
            oCommandSets.ReadAll(cts);
        }, cts.Token);
    }
