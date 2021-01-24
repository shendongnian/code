    [System.Web.Http.HttpPost]
    public void PostSimpleObject([FromUri]SimpleObject item)
    {
        var itemReceived = item;
    }    
