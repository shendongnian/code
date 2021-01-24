      private static void Getblobcontent(CloudBlobDirectory container)
            {
                foreach (IListBlobItem item in container.ListBlobs())
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        //int this method you could get the blob content in the directory
    
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
    
                        Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);
    
                    }
                    else if (item.GetType() == typeof(CloudPageBlob))
                    {
                        CloudPageBlob pageBlob = (CloudPageBlob)item;
                        //int this method you could get the blob content
    
                        Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);
    
                    }
                    else if (item.GetType() == typeof(CloudBlobDirectory))
                    {
                        CloudBlobDirectory directory = (CloudBlobDirectory)item;
                        Getblobcontent(directory);
    
                        Console.WriteLine("Directory: {0}", directory.Uri);
                    }
                }
            }
