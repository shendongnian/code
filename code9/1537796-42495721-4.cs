      public async Task CreateFile(string path)
        {
            Task<byte[]> headerTask = CreateHeaderAsync();
            Task<byte[]> filesTask = CombineFilesAsync();
            
            var allResults = await Task.WhenAll(headerTask, filesTask);
            byte[] header = allResults[0];
            byte[] files = allResults[1];
