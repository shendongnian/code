    public class KinesisEventProcessingService : IKinesisEventProcessingService
    {
        private IFileUploadService _fileUploadService;
        // constructor to attach Lazy loaded IFileUploadService
        public KinesisEventProcessingService(ILambdaContext context)
        {
            AWSLambdaFileProcessingServiceContext AWSLambdaFileProcessingServiceContext =
                LambdaContextFactory.BuildLambdaContext(context);
            _fileUploadService = AWSLambdaFileProcessingServiceContext.FileUploadService;
        }
        public void ProcessKinesisEvent(KinesisEvent kinesisEvent)
        {
            
            _fileUploadService.DoSomethingWithKinesisEvent(kinesisEvent);
            // ....
        }
    }
