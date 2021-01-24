    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, 
        TraceWriter log, Binder binder)
    {
        // Do await, not .Result
        string postData = await req.Content.ReadAsStringAsync();
        // ... get your HTTP parameters here
        var attributes = new Attribute[]
        {
             new StorageAccountAttribute(accountName),
             new BlobAttribute(blobName) // blobName should have "container/blob" format
        };
        var userBlobText = await binder.BindAsync<string>(attributes);
        // do whatever you want with this blob...
    }
