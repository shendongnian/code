    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
      // Cancel the previous attempt (if any) and start a new one.
      this.cts?.Cancel();
      this.cts = new CancellationTokenSource();
      try
      {
        bool loginSuccess = await AsyncLoginTask(this.cts.Token);
        // Resolve race condition where user cancels just as it completed.
        this.cts.Token.ThrowIfCancellationRequested();
        if (loginSuccess)
        {
          // Show main page
        }
      }
      catch (OperationCanceledException ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
    }
    private async Task<bool> AsyncLoginTask(CancellationToken cancellationToken = default(CancellationToken))
    {
      // Pass the token to HttpClient()
    }
