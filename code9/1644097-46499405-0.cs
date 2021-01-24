    static void ShowMessageBoxAndExit(string text, TimeSpan exitAfter)
    {
        using (CancellationTokenSource cts = new CancellationTokenSource())
        {
            Func<Task> exitTaskFactory = async () =>
            {
                try
                {
                    await Task.Delay(exitAfter, cts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // Expected if the user dismisses the
                    // message box before the wait is completed.
                }
                finally
                {
                    Environment.Exit(0);
                }
            };
            // Start the task.
            Task exitTask = exitTaskFactory();
            MessageBox.Show(text);
            // Cancel the wait if the user dismisses the
            // message box before our delay time elapses.
            cts.Cancel();
            // We don't want the user to be able to perform any more UI work,
            // so we'll deliberately block the current thread until our exitTask
            // completes. This also propagates task exceptions (if any).
            exitTask.GetAwaiter().GetResult();
        }
    }
