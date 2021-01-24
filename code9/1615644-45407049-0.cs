     public class UploadingController : ApiController
        {
            public Task<List<FileItem>> PostFile()
            {
                if (!Request.Content.IsMimeMultipartContent("form-data"))
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }
    
                var multipartStreamProvider = new AzureStorageMultipartFormDataStreamProvider(GetWebApiContainer());
                return Request.Content.ReadAsMultipartAsync<AzureStorageMultipartFormDataStreamProvider>(multipartStreamProvider).ContinueWith<List<FileItem>>(t =>
                {
                    if (t.IsFaulted)
                    {
                        throw t.Exception;
                    }
    
                    AzureStorageMultipartFormDataStreamProvider provider = t.Result;
                    return provider.Files;
                });
            }
    
    
            public static CloudBlobContainer GetWebApiContainer(string containerName = "webapi-file-container")
            {
                // Retrieve storage account from connection-string
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                   "your connection string");
    
                // Create the blob client 
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
    
                // Create the container if it doesn't already exist
                container.CreateIfNotExists();
    
                // Enable public access to blob
                var permissions = container.GetPermissions();
                if (permissions.PublicAccess == BlobContainerPublicAccessType.Off)
                {
                    permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                    container.SetPermissions(permissions);
                }
    
                return container;
            }
        }
    
    
        public class FileItem
        {
            /// <summary>
            /// file name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// size in bytes
            /// </summary>
            public string SizeInMB { get; set; }
            public string ContentType { get; set; }
            public string Path { get; set; }
            public string BlobUploadCostInSeconds { get; set; }
        }
    
       
        public class AzureStorageMultipartFormDataStreamProvider : MultipartFileStreamProvider
        {
            private CloudBlobContainer _container;
            public AzureStorageMultipartFormDataStreamProvider(CloudBlobContainer container)
                : base(Path.GetTempPath())
            {
                _container = container;
                Files = new List<FileItem>();
            }
    
            public List<FileItem> Files { get; set; }
    
            public override Task ExecutePostProcessingAsync()
            {
                // Upload the files to azure blob storage and remove them from local disk
                foreach (var fileData in this.FileData)
                {
                    var sp = new Stopwatch();
                    sp.Start();
                    string fileName = Path.GetFileName(fileData.Headers.ContentDisposition.FileName.Trim('"'));
                    CloudBlockBlob blob = _container.GetBlockBlobReference(fileName);
                    blob.Properties.ContentType = fileData.Headers.ContentType.MediaType;
    
                    //set the number of blocks that may be simultaneously uploaded
                    var requestOption = new BlobRequestOptions()
                    {
                        ParallelOperationThreadCount = 5,
                        SingleBlobUploadThresholdInBytes = 10 * 1024 * 1024 ////maximum for 64MB,32MB by default
                    };
    
                    //upload a file to blob
                    blob.UploadFromFile(fileData.LocalFileName, options: requestOption);
                    blob.FetchAttributes();
    
                    File.Delete(fileData.LocalFileName);
                    sp.Stop();
                    Files.Add(new FileItem
                    {
                        ContentType = blob.Properties.ContentType,
                        Name = blob.Name,
                        SizeInMB = string.Format("{0:f2}MB", blob.Properties.Length / (1024.0 * 1024.0)),
                        Path = blob.Uri.AbsoluteUri,
                        BlobUploadCostInSeconds = string.Format("{0:f2}s", sp.ElapsedMilliseconds / 1000.0)
                    });
                }
                return base.ExecutePostProcessingAsync();
            }
        }
