    class Program
    {
        const string url = "https://www.googleapis.com/download/storage/v1/b/storage-library-test-bucket/o/gzipped-text.txt?alt=media";
        
        static async Task Main()
        {
            //await HashResponseContent(CreateHandler(DecompressionMethods.None));
            //await HashResponseContent(CreateHandler(DecompressionMethods.GZip));
            await HashResponseContent(new MyHandler());
            Console.ReadLine();
        }
        private static HttpClientHandler CreateHandler(DecompressionMethods decompressionMethods)
        {
            return new HttpClientHandler { AutomaticDecompression = decompressionMethods };
        }
        public static async Task HashResponseContent(HttpClientHandler handler)
        {
            //Console.WriteLine($"Using AutomaticDecompression : '{handler.AutomaticDecompression}'");
            //Console.WriteLine($"Using SupportsAutomaticDecompression : '{handler.SupportsAutomaticDecompression}'");
            //Console.WriteLine($"Using Properties : '{string.Join('\n', handler.Properties.Keys.ToArray())}'");
            var client = new HttpClient(handler);
            var response = await client.GetAsync(url);
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            string text = Encoding.UTF8.GetString(content);
            Console.WriteLine($"Content: {text}");
            var hashHeader = response.Headers.GetValues("X-Goog-Hash").FirstOrDefault();
            Console.WriteLine($"Hash header: {hashHeader}");
            byteArrayToMd5(content);
            Console.WriteLine($"=====================================================================");
        }
        public static string byteArrayToMd5(byte[] content)
        {
            using (var md5 = MD5.Create())
            {
                var md5Hash = md5.ComputeHash(content);
                return Convert.ToBase64String(md5Hash);
            }
        }
        public static byte[] Compress(byte[] contentToGzip)
        {
            using (MemoryStream resultStream = new MemoryStream())
            {
                using (MemoryStream contentStreamToGzip = new MemoryStream(contentToGzip))
                {
                    using (GZipStream compressionStream = new GZipStream(resultStream, CompressionMode.Compress))
                    {
                        contentStreamToGzip.CopyTo(compressionStream);
                    }
                }
                return resultStream.ToArray();
            }
        }
    }
    public class MyHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var responseContent = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            Program.byteArrayToMd5(responseContent);
            var compressedResponse = Program.Compress(responseContent);
            var compressedResponseMd5 = Program.byteArrayToMd5(compressedResponse);
            Console.WriteLine($"recompressed response to md5 : {compressedResponseMd5}");
            return response;
        }
    }
