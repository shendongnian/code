    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    
    class Program
    {
        static async Task Main()
        {
            string url = "https://www.googleapis.com/download/storage/v1/b/"
                + "storage-library-test-bucket/o/gzipped-text.txt?alt=media";
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.None
            };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
    
            var response = await client.GetAsync(url);
            var hashHeader = response.Headers.GetValues("X-Goog-Hash").FirstOrDefault();
            Console.WriteLine($"Hash header: {hashHeader}");
            string text = null;
            using (var md5 = MD5.Create())
            {
                using (var cryptoStream = new CryptoStream(await response.Content.ReadAsStreamAsync(), md5, CryptoStreamMode.Read))
                {
                    using (var gzipStream = new GZipStream(cryptoStream, CompressionMode.Decompress))
                    {
                        using (var streamReader = new StreamReader(gzipStream, Encoding.UTF8))
                        {
                            text = streamReader.ReadToEnd();
                        }
                    }
                    Console.WriteLine($"Content: {text}");
                    var md5HashBase64 = Convert.ToBase64String(md5.Hash);
                    Console.WriteLine($"MD5 of content: {md5HashBase64}");
                }
            }
        }
    }
