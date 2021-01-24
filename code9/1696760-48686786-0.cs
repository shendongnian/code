     CloudStorageAccount storageAccount = CloudStorageAccount.Parse(SettingsProvider.Get("CloudStorageConnectionString", SettingType.AppSetting));
                    var blobClient = storageAccount.CreateCloudBlobClient();
                    var filesContainer = blobClient.GetContainerReference("your_containername");
                    filesContainer.CreateIfNotExists();
                    var durationHours = 24;
					//Generate SAS Token
                    var sasConstraints = new SharedAccessBlobPolicy
                    {
                        SharedAccessExpiryTime = DateTime.UtcNow.AddHours(durationHours),
                        Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Read
                    };
                    // Generate Random File Name using GUID
                    var StorageFileName = Guid.NewGuid() + DateTime.Now.ToString();
                    var blob = filesContainer.GetBlockBlobReference(StorageFileName);
                    var blobs = new CloudBlockBlob(new Uri(string.Format("{0}/{1}{2}", filesContainer.Uri.AbsoluteUri, StorageFileName, blob.GetSharedAccessSignature(sasConstraints))));
                    //Code for divide the file into the 4MB Chunk if its Greater than 4 MB then
                    BlobRequestOptions blobRequestOptions = new BlobRequestOptions()
                    {
                        SingleBlobUploadThresholdInBytes = 4 * 1024 * 1024, //1MB, the minimum
                        ParallelOperationThreadCount = 5,
                        ServerTimeout = TimeSpan.FromMinutes(30)
                    };
                    blob.StreamWriteSizeInBytes = 4 * 1024 * 1024;
					//Upload it on Azure Storage
                    blobs.UploadFromByteArrayAsync(item.Document_Bytes, 0, item.Document_Bytes.Length - 1, AccessCondition.GenerateEmptyCondition(), blobRequestOptions, new OperationContext());
