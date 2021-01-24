            string directory = "[path to save files]";
            string instance = "[Azure instance name]";
            string key = "[Azure key]";
            var account = new CloudStorageAccount(
            new StorageCredentialsAccountAndKey(
            instance,
            key
            ),
        false
        );
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("wad-iis-logfiles");
            //note that I pass the BlobRequestOptions of UseFlatBlobListing which returns all files regardless 
            //of nesting so that I don't have to walk the directory structure
            foreach (var blob in container.ListBlobs(new BlobRequestOptions() { UseFlatBlobListing = true }))
            {
                CloudBlob b = blob as CloudBlob;
                try
                {
                    b.FetchAttributes();
                    BlobAttributes blobAttributes = b.Attributes;
                    TimeSpan span = DateTime.Now.Subtract(blobAttributes.Properties.LastModifiedUtc.ToLocalTime());
                    int compare = TimeSpan.Compare(span, TimeSpan.FromHours(1));
                    //we don't want to download and delete the latest log file, because it is incomplete and still being
                    //written to, thus this compare logic
                    if (compare == 1)
                    {
                        b.DownloadToFile(directory + b.Uri.PathAndQuery);
                        b.Delete();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(instance + " download of logs failed!!!!" + e.Message);
                    return;
                }
            }
            Console.WriteLine(instance + " download of logs complete at " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() + "");
