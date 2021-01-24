     private void btnPopulate_Click(object sender, RoutedEventArgs e)
            {
                SynchronizationContext context = SynchronizationContext.Current;
    
                Thread backgroundThread = new Thread(
                        new ThreadStart(() =>
                        {
                            for (int n = 0; n < 100; n++)
                            {
                                Thread.Sleep(50);
                                context?.Post(new SendOrPostCallback((o) =>
                                {
    
                                    progressBar.Value = n;
                                }), null);
                            };
    
    
                        }
                    ));
                backgroundThread.Start();
            }
