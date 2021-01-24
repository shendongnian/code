            CloudBlobContainer container = new CloudBlobContainer(new Uri(ConfigurationManager.AppSettings["VOURL"]));
            //For each of the blobs, write the file name out. This will be needed for a comparison. 
            foreach (IListBlobItem blobItem in container.ListBlobs())
            {
                var blob = (CloudBlob)blobItem;
                if (blob != null)
                {
                    string name = blobItem.Uri.Segments.Last();
                    Console.WriteLine(name);
                    Console.WriteLine(blob.Properties.LastModified);
                }
            }
            Console.ReadKey();
