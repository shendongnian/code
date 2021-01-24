    private async void button_Click(object sender, EventArgs e)
    {
        // wait for a result from outer process
        var result = await RunProcessInBackGround();
        //do whatever you need in the UI-context
        loadData(result);
    }
    // T is a type of the result, should be changed
    private async Task<T> RunProcessInBackGround()
    {
        var tcs = new TaskCompletionSource<T>();
        // run your process
        var process  new Process {/* your params here */};
        process.Exited += (sender, args) =>
            {
                // here your process has already done his job
                tcs.SetResult(result);
                process.Dispose();
            };
        // process will start as a separate process, no need to create a thread to wait for it
        process.Start();
        // return the task which will be awaited for
        return tcs.Task;
    }
