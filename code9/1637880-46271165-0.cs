      var connectionString = "DefaultEndpointsProtocol=https;AccountName=accountxxxx;AccountKey=xxxxxxxxx;EndpointSuffix=core.windows.net";
      CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
      CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
      CloudBlobContainer container = blobClient.GetContainerReference("output");
      var blobs = container.ListBlobs();
      var ftpConnectionSNow = new ConnectionInfo("HostName", "username", new PasswordAuthenticationMethod("username","password"));
      const string ftpUploadPathSNow = "/home/xxx/sftptest4tom"; //sftp path
      foreach (var blob in blobs)
      {
           CloudBlockBlob blobSNow = (CloudBlockBlob) blob;
           var fileName = blobSNow.Name;
           Console.WriteLine($"BlobName:{fileName} ---BlobSize:{blobSNow.Properties.Length}");
           var ftpFilePathSNow = $"{ftpUploadPathSNow}/{fileName}";
           using (var stream = new MemoryStream())
           {
              // Downloading the blob containt to the memory stream
              blobSNow.DownloadToStream(stream);
              try
                {
                   using (var client = new SftpClient(ftpConnectionSNow))
                   {
                       client.BufferSize = 999424;
                       client.Connect();
                       stream.Position = 0;
                       client.UploadFile(stream, ftpFilePathSNow, true);
                       client.Disconnect();
                    }
                }
                catch (Exception)
                {
                            // ToDo
                }
           }
      }
