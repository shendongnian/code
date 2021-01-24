    using System.Diagnostics;
    // handle event in fire-and-forget manner
    async void btn_Click(object sender, EventArgs e)
    {
        var computerNames = { "foo", "bar", "baz" };
        foreach(String computerName in computerNames)
        {
            var compCancelSource = new CancellationTokenSource();
            // asynchronically wait for next computer info
            var compInfo = await GetComputerInfo(computerName, compCancelSource. Token);
            // We are in UI context here
            ShowOutputInGui(compInfo);
            RunOnGuiThread(compInfo);
        }
    }
    private Task<ComputerInfo> GetComputerInfo(String machineName, CancellationToken token)
    {
        var pingTime = Task.Factory.StartNew(
            // action to run
            () => GetPingTime(machineName),
            //token to cancel
            token,
            // notify the thread pool that this task could take a long time to run,
            // so the new thread probably will be used for it
            TaskCreationOptions.LongRunning,
            // execute all the job in a thread pool
            TaskScheduler.Default);
        var processes = Task.Run(() => Process.GetProcesses(machineName), token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        // and loads more
        await Task.WhenAll(pingtime, processes, etc);
        return new ComputerInfo(pingTime.Result, processes.Result, etc);
        //var tcs = new TaskCompletionSource<ComputerInfo>();
        //Task.WhenAll(pingtime, processes, etc)
        //    .ContinueWith(aggregateTask =>
        //        if (aggregateTask.IsCompleted)
        //        {
        //            tcs.SetResult(new ComputerInfo(
        //                aggregateTask.Result[0],
        //                aggregateTask.Result[1],
        //                etc));
        //        }
        //        else
        //        {
        //            // cancel or error handling
        //        });
        // return the awaitable task
        //return tcs.Task;
    }
