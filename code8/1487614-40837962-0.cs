    public async Task<bool> Set_Listing_Records_ResponseHandler(string responseChannelSuffix, Action<List<AIDataSetListItem>> successHandler, Action<Exception> errorHandler)
    {
        // Subscribe to Query Response Channel and Wire up Handler for Query Response
        await this.ConnectAsync();
        return await this.SubscribeTo_QueryResponseChannelAsync(responseChannelSuffix, new FayeMessageHandler(delegate (FayeClient client, FayeMessage message) {
            _MessageHandlerContext.Post(delegate {
                try
                {
                    ...
                }
                catch (Exception e)
                {
                    ...
                }
            }, null);
        }));
    }
