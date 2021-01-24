    class YourClass
    {
        private CancellationTokenSource cts;
        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // if cts isn't null, then a saving task is already running -> cancel it
            if (cts != null)
            {
                cts.Cancel();
            }
            else
            {
                // otherwise, create a new token source and await the saving task
                // this runs on the UI thread
                cts = new CancellationTokenSource();
                SaveBtn.Content = "Saving";
                try
                {
                    // the task itself will probably run on a thread pool's thread,
                    // but after it finishes, this method will continue on the UI thread
                    await Task.Run(() => SaveAsPng(cts.Token), cts.Token);
                }
                catch (OperationCanceledException)
                {
                    // insert your cancellation handling if needed
                    // this runs on the UI thread
                }
                finally
                {
                    // This runs on the UI thread
                    SaveBtn.Content = "Save";
                    cts.Dispose();
                    cts = null;
                }
            }
        }
        private void SaveAsPng(CancellationToken ct)
        {
            // your synchronous implementation
            // don't forget to check ct.IsCancellationRequested in this method
            // or call ct.ThrowIfCancellationRequested()
            // no need to start any tasks here
            // don't use dispatchers, schedulers etc.
            // just a plain old synchronous code
        }
    }
