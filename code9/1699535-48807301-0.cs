    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                "<AccountName>",
                "<AccountKey>");
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("sasimagecontainer");
            container.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            var sasUri = GetContainerSasUri(container);
            var container2 = new CloudBlobContainer(new Uri(sasUri));
            var blob2 = container2.GetBlockBlobReference("blobCreatedViaSAS.txt");
            blob2.UploadFromFileAsync(@"D:\test.txt").GetAwaiter().GetResult();
        }
        private static string GetContainerSasUri(CloudBlobContainer container)
        {
            //Set the expiry time and permissions for the container.
            //In this case no start time is specified, so the shared access signature becomes valid immediately.
            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(24);
            sasConstraints.Permissions = SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Write |
                                         SharedAccessBlobPermissions.Create |
                                         SharedAccessBlobPermissions.Add | SharedAccessBlobPermissions.Read;
            //Generate the shared access signature on the container, setting the constraints directly on the signature.
            var sasContainerToken = container.GetSharedAccessSignature(sasConstraints);
            //Return the URI string for the container, including the SAS token.
            return container.Uri + sasContainerToken;
        }
    }
