    #r "Microsoft.WindowsAzure.Storage"
    using Microsoft.WindowsAzure.Storage.Blob;
    public static void Run(Stream input, Stream output, 
                           CloudBlobContainer container, TraceWriter log)
    {
        var blobs = container.ListBlobs();
        log.Info($"{blobs.Count()} blobs in container.");
    }
