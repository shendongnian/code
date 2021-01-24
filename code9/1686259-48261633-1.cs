        private static void RunSingleTask(ref CancellationTokenSource cts, int delay, Action func)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
            cts = new CancellationTokenSource();
            var token = cts.Token;
            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(delay, token);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
                await Application.Current.Dispatcher.BeginInvoke(func); 
            });
        }
