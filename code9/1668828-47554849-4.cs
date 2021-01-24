    public class SomeStageInAPipeline
    {
        private readonly IBlobAccessClient _srcBlobAccessClient;
        private readonly IBlobAccessClient _destBlobAccessClient;
        public SomeStageInAPipeline(
            IBlobAccessClient srcBlobAccessClient,
            IBlobAccessClient destBlobAccessClient)
        {
            _srcBlobAccessClient = srcBlobAccessClient;
            _destBlobAccessClient = destBlobAccessClient;
        }
    }
