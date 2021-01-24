    public class SomeStageInAPipeline
    {
        private readonly IBlobAccessClient _srcBlobAccessClient;
        private readonly IBlobAccessClient _destBlobAccessClient;
        public SomeStageInAPipeline (Container container)
        {
            var clients = container.GetInstance<BlobAccessClients>();
            _srcBlobAccessClient = clients.Src;
            _destBlobAccessClient = clients.Dest;
        }
    }
