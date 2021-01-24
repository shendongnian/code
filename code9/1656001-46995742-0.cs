    async void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //Update default status bar text routinely
        try
        {
            if (ChecEnabled())
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    StatusText.Text = String.Format("Status: Enabled. Watching for changes…");
                });
            }
            else
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    StatusText.Text = String.Format("Status: Disabled");
                });
            }
        }
        catch (ObjectDisposedException)
        {
            //Window closed and disposed timer on different thread
        }
    
        //System Checks
        await Task.Run(()=>UpdateSystemReadyStatus());
    }
