    int i = 1;
    Task.Run(() =>
                {
                    for (; i <= 9999; i++)
                    {
                        System.Threading.Thread.Sleep(1500); //simulate long-running operation by sleeping for 1.5s seconds... 
                        label1.Dispatcher.BeginInvoke(new Action(() => label1.Content = (i / 9999) * 100 + "%"));
                    }
                }).ContinueWith(t =>
                {
                  MessageBox.Show("done..." + i.ToString());
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
