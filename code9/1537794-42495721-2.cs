      public async Task CreateFile(string path)
        {
            Task<byte[]> headerTask = CreateHeaderAsync();
            Task<byte[]> filesTask = CombineFilesAsync();
            var waitlist = new Task<byte[]>[2];
            waitlist[0] = headerTask;
            waitlist[1] = filesTask;
            var allResults = await Task.WhenAll(waitlist); 
            byte[] header = allResults[0];
            byte[] files = allResults[1];
