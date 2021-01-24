    public override void Run()
            {
                try
                {
                    RunAsync(cancellationTokenSource.Token).Wait();
                }
                finally
                {
                    runCompleteEvent.Set();
                }
            }
