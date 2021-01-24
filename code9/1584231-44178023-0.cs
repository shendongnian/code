    private CancelationTokenSource _cancellationTokenSource= new CancelationTokenSource();
    
        private void searchContent_TextChanged(object sender, EventArgs e)
        {
    
    			Task.Run(async () =>
                    {
                        
                        _cancellationTokenSource.Cancel();
                        _cancellationTokenSource = new CancellationTokenSource();
                        var token = _cancellationTokenSource.Token;
    
                        try
                        {
                            await Task.Delay(TimeSpan.FromSeconds(TimeSpan.FromSeconds(2), token).ContinueWith(r =>
                            {
                                if (!token.IsCancellationRequested)
                                {
                                    addBarcodeProductToCart ();
                                }
                            }, token);
                        }
                        catch (TaskCanceledException e)
                        {
                            //noop
                        }
                    }).ConfigureAwait(false);
    				
    				
    				
    }
