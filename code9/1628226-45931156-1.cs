    [FunctionName("ScanFile")]
    public static void Run([BlobTrigger("tobescanned/{name}")]CloudBlockBlob myBlob, string name,
        IDictionary<string, string> metadata)
    {
        var destinationContainer = myBlob.Container.ServiceClient.GetContainerReference(metadata["Destination"]);
        destinationContainer.CreateIfNotExists();
        CloudBlockBlob outputBlob = destinationContainer.GetBlockBlobReference(name);
        outputBlob.StartCopy(myBlob);
    }
