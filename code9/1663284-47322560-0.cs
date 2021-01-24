    var tcsGotData = new TaskCompletionSource<bool>();
    var output = new ConcurrentBag<string>();
    var error = new ConcurrentBag<string>();
    process.OutputDataReceived += (sender, e) =>
    {
        output.Add(e.Data);
        tcsGotData.TrySetResult(true);
    };
    process.ErrorDataReceived += (sender, e) =>
    {
        error.Add(e.Data);
        tcsGotData.TrySetResult(true);
    };
    process.Exited += (sender, e) =>
    {
        tcsGotData.Task.Wait(); // You might want to put a timeout here, though ...
        tcs.SetResult(new CmdResult
        {
            Arguments = arguments,
            Output = string.Join("", output),
            Error = string.Join("", error),
            ExitCode = process.ExitCode
        });
        process.Dispose();
    };
