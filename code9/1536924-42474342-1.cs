    private async Task RunAsync(CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    ScaleImage();
                    await Task.Delay(10000);
                }
            }
    
            private void ScaleImage()
            {
                Trace.TraceInformation("Scaling Image");
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("Myconnectionstring");
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference("cadqueue");
                CloudQueueMessage retrievedMessage = queue.GetMessage();
    
                if (retrievedMessage.AsString != null || retrievedMessage.AsString != "")
                {
                    string[] msg = retrievedMessage.AsString.Split(' ');
    
                    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                    CloudTable table = tableClient.GetTableReference("cadtable");
    
                    TableOperation retrieveOperation = TableOperation.Retrieve<ImageEntity>("Images", msg[0]);
                    TableResult retrievedResult = table.Execute(retrieveOperation);
                    var container = GetImageBlobContainer();
                    msg[2] = "mini_" + msg[2];
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(msg[2]);
                    blockBlob.Properties.ContentType = msg[1];
    
                    Image img;
                    var webClient = new WebClient();
                    byte[] imgBytes = webClient.DownloadData(((ImageEntity)retrievedResult.Result).Full_img);
                    using (var ms = new MemoryStream(imgBytes))
                    {
                        img = Image.FromStream(ms);
                    }
                    Image thumb = ScaleImage(img, 220, 160);
                    var fileBytes = imageToByteArray(thumb);
                    await blockBlob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);
    
                    ImageEntity ent = (ImageEntity)retrievedResult.Result;
                    if (ent != null)
                    {
                        ent.Mini_img = "https://cadwebstorage.blob.core.windows.net/cadblob/" + msg[2];
                        TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(ent);
                        table.Execute(insertOrReplaceOperation);
                    }
                    else
                    {
                        Console.WriteLine("Entity could not be retrived.");
                    }
    
                    queue.DeleteMessage(retrievedMessage);
                }
    
            }
