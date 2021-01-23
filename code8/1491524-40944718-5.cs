    public async Task<string> jsonConvert(string message)
    {
        RootObject rootObject = new RootObject
        {
            Default = message,
            GCM = new GCM { Data = new Data { Message = message } }
        };
        var msg = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(rootObject));
        return msg;
    }
