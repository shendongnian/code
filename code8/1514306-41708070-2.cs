    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceContract(Namespace = ServiceNamespace)]
    [DataContractFormat]
    public class FileContentService : IFileContentService, INullContract
    {
        public FileContentService()
        {
            client = new AmazonS3Client(Amazon.RegionalEndpoint.USEast1);
        }
        [OperationContract, WebGet(UriTemplate = "Files/{fileId}")]
        public io.Stream GetFileContent(string fileId)
        {
            GetObjectRequest request = new GetObjectRequest 
            {
                BucketName = bucketName,
                Key = fileId
            };
            var response = client.GetObject(request);
            // copy relevant headers (MIME, ETag, Cache-Control, etc...)
            // WebOperationContext.Current.OutgoingResponse.SetETag(etag);
            // WebOperationContext.Current.OutgoingResponse.ContentType = foo;
            // WebOperationContext.Current.OutgoingResponse.Headers
            //     .Add(HttpResponseHeader.CacheControl, "{cache options}");
            return response.ResponseStream;
        }
    }
    public class FileContentServiceManager : IDisposable
    {
        private ServiceHost shThis;
        public FileContentServiceManager()
        {
            shThis = new ServiceHost(typeof(FileContentService), new Uri("https://localhost/foo/bar"));
            shThis.AddServiceEndpoint(typeof(FileContentService), GetBinding(), "")
                .Behaviors.Add(new WebHttpBehavior());
            shThis.Open();
        }
        public void Dispose()
        {
            shThis.Close();
        }
        static Binding GetBinding()
        {
            var b = new WebHttpBinding();
            b.MaxReceivedMessageSize = 28 * 1024 * 1024 * 2;
            b.ReaderQuotas.MaxBytesPerRead = 4096 * 1024;
            b.ReaderQuotas.MaxDepth = 32;
            b.ReaderQuotas.MaxStringContentLength = 4096 * 1024;
            b.ReaderQuotas.MaxArrayLength = 4096 * 1024;
            b.Security.Mode = WebHttpSecurityMode.Transport;
            CustomBinding result = new CustomBinding(b);
            WebMessageEncodingBindingElement webMEBE = result.Elements.Find<WebMessageEncodingBindingElement>();
            webMEBE.ContentTypeMapper = new MyMapper();
            return result;
        }
        class MyMapper : WebContentTypeMapper
        {
            public override WebContentFormat GetMessageFormatForContentType(string contentType)
            {
                return WebContentFormat.Raw; // always
            }
        }
    }
