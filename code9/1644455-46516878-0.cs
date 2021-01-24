    public static class Example
    { 
        private class Dto
        {
            public Dto(string filePath, byte[] data)
            {
                FilePath = filePath;
                Data = data;
            }
            public string FilePath { get; }
            public byte[] Data { get; }
        }
        public static async Task ProcessFiles(string path)
        {
            var getFilesBlock = new TransformBlock<string, Dto>(filePath => new Dto(filePath, File.ReadAllBytes(filePath))); //Only lets one thread do this at a time.
            var hashFilesBlock = new TransformBlock<Dto, Dto>(dto => HashFile(dto), 
                    new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = Environment.ProcessorCount, //We can multi-thread this part.
                                                      BoundedCapacity = 50}); //Only allow 50 byte[]'s to be waiting in the queue. It will unblock getFilesBlock once there is room.
            var writeToDatabaseBlock = new ActionBlock<Dto>(WriteToDatabase,
                  new ExecutionDataflowBlockOptions {BoundedCapacity = 50});//MaxDegreeOfParallelism defaults to 1 so we don't need to specifiy it.
            //Link the blocks together.
            getFilesBlock.LinkTo(hashFilesBlock, new DataflowLinkOptions {PropagateCompletion = true});
            hashFilesBlock.LinkTo(writeToDatabaseBlock, new DataflowLinkOptions {PropagateCompletion = true});
            //Queue the work for the first block.
            foreach (var filePath in Directory.EnumerateFiles(path))
            {
                await getFilesBlock.SendAsync(filePath).ConfigureAwait(false);
            }
            //Tell the first block we are done adding files.
            getFilesBlock.Complete();
            await writeToDatabaseBlock.Completion.ConfigureAwait(false);
        }
        private static Dto HashFile(Dto dto)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                return new Dto(dto.FilePath, md5.ComputeHash(dto.Data));
            }
        }
        private static async Task WriteToDatabase(Dto arg)
        {
            //Write to the database here.
        }
    }
