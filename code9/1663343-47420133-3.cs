    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
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
            var client = new HttpClient(new Intercepter(handler));
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
    
            var response = await client.GetAsync(url);
            var hashHeader = response.Headers.GetValues("X-Goog-Hash").FirstOrDefault();
            Console.WriteLine($"Hash header: {hashHeader}");
            HttpContent content1 = response.Content;
            byte[] content = await content1.ReadAsByteArrayAsync();
            string text = Encoding.UTF8.GetString(content);
            Console.WriteLine($"Content: {text}");
            var md5Hash = ((HashingContent)content1).Hash;
            var md5HashBase64 = Convert.ToBase64String(md5Hash);
            Console.WriteLine($"MD5 of content: {md5HashBase64}");
        }
    
        public class Intercepter : DelegatingHandler
        {
            public Intercepter(HttpMessageHandler innerHandler) : base(innerHandler)
            {
            }
    
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = await base.SendAsync(request, cancellationToken);
                response.Content = new HashingContent(await response.Content.ReadAsStreamAsync());
                return response;
            }
        }
    
        public sealed class HashingContent : HttpContent
        {
            private readonly StreamContent streamContent;
            private readonly MD5 mD5;
            private readonly CryptoStream cryptoStream;
            private readonly GZipStream gZipStream;
    
            public HashingContent(Stream content)
            {
                mD5 = MD5.Create();
                cryptoStream = new CryptoStream(content, mD5, CryptoStreamMode.Read);
                gZipStream = new GZipStream(cryptoStream, CompressionMode.Decompress);
                streamContent = new StreamContent(gZipStream);
            }
    
            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context) => streamContent.CopyToAsync(stream, context);
            protected override bool TryComputeLength(out long length)
            {
                length = 0;
                return false;
            }
    
            protected override Task<Stream> CreateContentReadStreamAsync() => streamContent.ReadAsStreamAsync();
    
            protected override void Dispose(bool disposing)
            {
                try
                {
                    if (disposing)
                    {
                        streamContent.Dispose();
                        gZipStream.Dispose();
                        cryptoStream.Dispose();
                        mD5.Dispose();
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
    
            public byte[] Hash => mD5.Hash;
        }
    }
