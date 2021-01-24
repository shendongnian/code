    #r "Microsoft.WindowsAzure.Storage"
    using Microsoft.WindowsAzure.Storage.Blob;
    public static void Run(CloudBlockBlob myBlob, string name, TraceWriter log)
    {   
        //blob has public read access permission
        var blobData = new BlobData() { path = myBlob.Uri.ToString() };
        
        //blob is private, generate a SAS token for this blob with the limited permission(s)
        var blobSasToken=myBlob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                {
                     SharedAccessExpiryTime =DateTimeOffset.UtcNow.AddDays(2),
                     Permissions = SharedAccessBlobPermissions.Read
                }));
        var blobData = new BlobData() 
              { 
                path = $"{myBlob.Uri.ToString()}{blobSasToken}"
              };
        //TODO:
    }
