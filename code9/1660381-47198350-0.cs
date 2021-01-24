    private async void PostToServer()
    {
       //Do complex task without returning anything.
       //Like posting data to server.
    }
    async Task<ObjPrice> getprice()
    {
        //Do complex task and return result.
        //Like fetching the value for ObjPrice from server.
        return result;
    }
    public void Bar()
    {
        var objStockcheck = await getprice();         
        await PostToServer();
    }
