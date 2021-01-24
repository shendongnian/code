    process.Exited += (sender, e) =>
    {
        // here
        ((Process)sender).WaitForExit();
        tcs.SetResult(new CmdResult
        {
            Arguments = arguments,
            Output = output.ToString(),
            Error = error.ToString(),
            ExitCode = process.ExitCode
        });
        process.Dispose();
    };
