    #r "Microsoft.WindowsAzure.Storage"
    using Microsoft.WindowsAzure.Storage.Table;
    using Microsoft.WindowsAzure.Storage.Blob;
    public static void Run(CloudBlockBlob inputBlob, ICollector<UploadFile> outTable, TraceWriter log)
    {   
        string blobUri=inputBlob.StorageUri.PrimaryUri.ToString();
        log.Info($"C# Blob  trigger function triggered, blob path: {blobUri}");
        outTable.Add(new UploadFile()
        {
            PartitionKey = "Functions",
            RowKey = Guid.NewGuid().ToString(),
            Name = blobUri
        });
    }
    public class UploadFile : TableEntity
    {
        public string Name { get; set; }
    }
