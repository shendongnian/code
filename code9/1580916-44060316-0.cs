     CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
       "connectionstring");
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference("contiainername");
    
                // Loop over items within the container and output the content, length and URI.
                foreach (IListBlobItem item in container.ListBlobs(null, false))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        string text;
                        using (var memoryStream = new MemoryStream())
                        {
                            blob.DownloadToStream(memoryStream);
    
                            //we get the content from the blob
                            //sine in my blob this is txt file,
                            text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                        }
                       Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);
                       Console.WriteLine(text);
                    }
                    else if (item.GetType() == typeof(CloudPageBlob))
                    {
                        CloudPageBlob pageBlob = (CloudPageBlob)item;
    
                        Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);
    
                    }
                    else if (item.GetType() == typeof(CloudBlobDirectory))
                    {
                        CloudBlobDirectory directory = (CloudBlobDirectory)item;
                        Getblobcontent(directory);
                        Console.WriteLine("Directory: {0}", directory.Uri);
                    }
                }
