    private static async Task Test2()
    {
        var url = @"https://www.googleapis.com/download/storage/v1/b/storage-library-test-bucket/o/gzipped-text.txt?alt=media";
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.None
        };
        var client = new HttpClient(handler);
        client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
        var response = await client.GetAsync(url);
        var raw = await response.Content.ReadAsByteArrayAsync();
        var hashHeader = response.Headers.GetValues("X-Goog-Hash").FirstOrDefault();
        Debug.WriteLine($"Hash header: {hashHeader}");
        bool match = false;
        using (var md5 = MD5.Create())
        {
            var md5Hash = md5.ComputeHash(raw);
            var md5HashBase64 = Convert.ToBase64String(md5Hash);
            match = hashHeader.EndsWith(md5HashBase64);
            Debug.WriteLine($"MD5 of content: {md5HashBase64}");
        }
        if (match)
        {
            var memInput = new MemoryStream(raw);
            var gz = new GZipStream(memInput, CompressionMode.Decompress);
            var memOutput = new MemoryStream();
            gz.CopyTo(memOutput);
            var text = Encoding.UTF8.GetString(memOutput.ToArray());
            Console.WriteLine($"Content: {text}");
        }
    }
