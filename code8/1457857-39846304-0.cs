    private async void btn_Click(object sender, RoutedEventArgs e)
    {
        BtnEnabled = false;
        Results = string.Empty;
        // whould like to displany wait spinner
        //LongProcess();
        cts = new CancellationTokenSource();
        try
        {
            //cts.Cancel(); just for test
            string result = await WaitAsynchronouslyAsync(cts.Token);
            //string result = await WaitSynchronously();
                
            BtnEnabled = true;
            Results = result;
        }
        catch (OperationCanceledException)
        {
            Results = "Operation canceled";  // this is not called
        }
        cts = null;
    }
    // The following method runs asynchronously. The UI thread is not
    // blocked during the delay. You can move or resize the Form1 window 
    // while Task.Delay is running.
    public async Task<string> WaitAsynchronouslyAsync(CancellationToken ct)
    {
        //DataBaseQuery();  // this just runs async
        //SqlCommand cmd = new SqlCommand();
        //await cmd.ExecuteScalarAsync(ct);
        await Task.Delay(10000);
        return "Finished";
    }
