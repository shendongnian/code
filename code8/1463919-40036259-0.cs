    public async Task SetStatusMessage(string pStatusMessage)
    {
        CancellationTokenSource localToken;
    
        try
        {
            if (tokenSource != null)
                tokenSource.Cancel();
    
            tokenSource = new CancellationTokenSource();
    
            localToken = this.tokenSource;
    
            this.txtStatusMessage.Text = pStatusMessage;
    
            await Task.Delay(5000, localToken.token);
    
            this.txtStatusMessage.Text = "";
        }
        catch (TaskCanceledException) {}
        finally
        {
            localToken.Dispose();
        }
    }
