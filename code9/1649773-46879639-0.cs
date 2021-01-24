    public async Task<Stream> GetBlobsAsZipAsync(string container)
        {
            BlobContinuationToken continuationToken = null;
            BlobResultSegment resultSegment = null;
            byte[] buffer = new byte[4194304];
            MemoryStream ms = new MemoryStream();
            CloudBlobContainer cont = _cbc.GetContainerReference(container);
            resultSegment = await cont.ListBlobsSegmentedAsync(String.Empty, true, BlobListingDetails.Metadata, null, continuationToken, null, null);
            using (var za = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                do
                {
                    foreach (var bItem in resultSegment.Results)
                    {
                        var iBlob = bItem as CloudBlockBlob;
                        var ze = za.CreateEntry(iBlob.Name);
                        using (var fs = await iBlob.OpenReadAsync())
                        {
                            using (var dest = ze.Open())
                            {
                                int count = await fs.ReadAsync(buffer, 0, buffer.Length);
                                while (count > 0)
                                {
                                    await dest.WriteAsync(buffer, 0, count);
                                    count = await fs.ReadAsync(buffer, 0, buffer.Length);
                                }
                            }                                
                        }
                    }
                    continuationToken = resultSegment.ContinuationToken;
                } while (continuationToken != null);
            }
            return ms;
        }
