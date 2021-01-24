    CloudBlobContainer container = cloudBlobClient.GetContainerReference("mycontainer");   
    CloudBlockBlob blob = container.GetBlockBlobReference("testimg.PNG");
    
    SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
    sasConstraints.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);
    sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddDays(7);
    sasConstraints.Permissions = SharedAccessBlobPermissions.Read;
    
                
    string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);
    string URL = blob.Uri + sasBlobToken;
