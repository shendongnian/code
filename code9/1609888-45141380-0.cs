    private CancellationTokenSource CTS = new CancellationTokenSource();
    
    public async Task StartSearch(string query)
        {
            this.CTS.Cancel(true);
            this.CTS = new CancellationTokenSource();
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        if (this.CTS.IsCancellationRequested)
                        {
                            return;
                        }
                        // Your actual searching logic... If you decide to update the UI here then make sure this runs on UI Thread.
                        if (this.CTS.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                       // Logger...
                    }
                }, this.CTS.Token);
            }
            catch (TaskCanceledException taskCnclErr)
            {
                // You can ignore this error
            }
            catch (Exception ex)
            {
                //Logger...
                throw;
            }
            finally
            {
                
            }
        }
