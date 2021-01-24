    private async void PostToServer(Model Data)
    {
       //Do complex task without returning anything.
       //Like posting data to server.
       //...Do something with model
      await context.SaveAsync();
    }
    async Task<ObjPrice> getprice()
    {
        //Do complex task and return result.
        //Like waiting for some other event to update the price.
        return await WaitForPriceChangeAsync();
    }
    public void Bar()
    {
        var objStockcheck = await WaitForPriceUpdate();         
        await PostToServer();
    }
