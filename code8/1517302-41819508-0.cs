    private static void ParallelDownloadBlob(Stream outPutStream, CloudBlockBlob blob)
    {
        blob.FetchAttributes();
        int bufferLength = 1 * 1024 * 1024;//1 MB chunk
        long blobRemainingLength = blob.Properties.Length;
        Queue<KeyValuePair<long, long>> queues = new Queue<KeyValuePair<long, long>>();
        long offset = 0;
        while (blobRemainingLength > 0)
        {
            long chunkLength = (long)Math.Min(bufferLength, blobRemainingLength);
            queues.Enqueue(new KeyValuePair<long, long>(offset, chunkLength));
            offset += chunkLength;
            blobRemainingLength -= chunkLength;
        }
        Parallel.ForEach(queues,
            new ParallelOptions()
            {   
                //Gets or sets the maximum number of concurrent tasks
                MaxDegreeOfParallelism = 10
            }, (queue) =>
                {
                    using (var ms = new MemoryStream())
                    {
                        blob.DownloadRangeToStream(ms, queue.Key, queue.Value);
                        lock (outPutStream)
                        {
                            outPutStream.Position = queue.Key;
                            var bytes = ms.ToArray();
                            outPutStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                });
    }
