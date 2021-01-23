    public async Task<bool> Set_Listing_Records_ResponseHandler(
        string responseChannelSuffix, 
        Action<List<AIDataSetListItem>> successHandler, 
        Action<Exception> errorHandler)
    {
      // Subscribe to Query Response Channel and Wire up Handler for Query Response
      await this.ConnectAsync();
      var tcs = new TaskCompletionSource<FayeMessage>();
      await this.SubscribeTo_QueryResponseChannelAsync(responseChannelSuffix, new FayeMessageHandler(
          (client, message) => tcs.TrySetResult(message)));
      var message = await tcs.Task;
      // We are already back on the UI thread here; no need for Dispatcher.
      try
      {
        ...
      }
      catch (Exception e)
      {
        ...
      }
    }
