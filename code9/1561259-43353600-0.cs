    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, 
        TraceWriter log, IBinder binder)
    {
        // Do await, not .Result
        string postData = await req.Content.ReadAsStringAsync();
        // ... get your HTTP parameters here
        var attributes = new Attribute[]
        {
             new StorageAccountAttribute(accountName),
             new BlobAttribute(blobName)
        };
        using (var userBlobText = await binder.BindAsync<string>(attributes))
        {
             // do whatever you want with this blob...
        }
    }
