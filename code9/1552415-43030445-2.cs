    public static async Task Run(string myEventHubMessage, Binder binder)
    {
        var path = ...;
        using (var writer = binder.Bind<TextWriter>(new BlobAttribute(path)))
        {
            writer.Write(myEventHubMessage);
        }
    }
