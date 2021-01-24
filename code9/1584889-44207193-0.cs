        public async Task<List<Uri>> GetFullBlobsAsync()
        {
            var blobList = await Container.ListBlobsSegmentedAsync(string.Empty, false, BlobListingDetails.None, int.MaxValue, null, null, null);
            
            return (from blob in blobList
                                 .Results
                                 .OfType<CloudBlobDirectory>() 
                    select blob).ToList();
        }
