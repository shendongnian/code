    // this is the AWS Lambda function - refactored to only accept a request and pass into newly created service (where the processing logic lives)
    public class AWSLambdaFileProcessingService
    {
        [LambdaSerializer(typeof(JsonSerializer))]
        public void ProcessKinesisMessageById(KinesisEvent kinesisEvent, ILambdaContext context)
        {
            Console.WriteLine("Processing Kinesis Request");
            IKinesisEventProcessingService kinesisEventProcessingService = new KinesisEventProcessingService(context);
            kinesisEventProcessingService.ProcessKinesisEvent(kinesisEvent);
        }
    }
    // this is a new service to encapsulate all services that act on input
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
    // implementation of ILambdaContext that can also be used for testing
    // this context allows for override of attached services in testing 
    public class AWSLambdaFileProcessingServiceContext : ILambdaContext
    {
        public AWSLambdaFileProcessingServiceContext()
        {
            FileUploadService = default(IFileUploadService);
        }
        public string AwsRequestId { get; }
        // ... ILambdaContext properties
        public TimeSpan RemainingTime { get; }
        // Dependencies
        public IFileUploadService FileUploadService { get; set; }
       
    }
    // static class for attaching dependencies to the context
    public static class LambdaContextFactory
    {
        public static AWSLambdaFileProcessingServiceContext BuildLambdaContext(ILambdaContext context)
        {
            // cast to implementation that has dependencies as properties of context
            AWSLambdaFileProcessingServiceContext serviceContext = default(AWSLambdaFileProcessingServiceContext);
            if (context.GetType().Equals(typeof(AWSLambdaFileProcessingServiceContext)))
            {
                serviceContext = (AWSLambdaFileProcessingServiceContext)context;
            }
            else
            {
                serviceContext = new AWSLambdaFileProcessingServiceContext();
            }
            // lazily inject dependencies
            if (serviceContext.FileUploadService == null)
            {
                serviceContext.FileUploadService = FileUploadService.Value;
            }
            return serviceContext;
        }
        public static Lazy<IFileUploadService> FileUploadService = new Lazy<IFileUploadService>(() =>
        {
            ISystemEnvironmentService env = new SystemEnvironmentService();
            IAmazonS3 s3 = new AmazonS3Client(
                env.GetEnvironmentVariable("AWS_S3_KEY"),
                env.GetEnvironmentVariable("AWS_S3_SECRET_KEY")
            );
            IFileUploadService service = new AWSFileUploadService(s3);
            return service;
        });
        /// <summary>
        /// This tests asserts that the Lambda function handles the input and calls the mocked service
        /// </summary>
        [Fact()]
        public void TestKinesisMessage()
        {
            // arrange
            string testMessage = "59d6572f028c52057caf13ff";
            string testStream = "testStream";
            IFileUploadService FileUploadService = new AWSFileUploadService(new Mock<IAmazonS3>().Object);
            // create the custom context and attach above mocked FileUploadService from Lazy factory
            var context = new AWSLambdaFileProcessingServiceContext();
            context.FileUploadService = FileUploadService;
            var lambdaFunction = new AWSLambdaFileProcessingService();
            KinesisEvent kinesisEvent = BuildKinesisTestRequest(testMessage, testStream);
            // act & assert
            try
            {
                lambdaFunction.ProcessKinesisMessageById(kinesisEvent, context);
            }
            catch (Exception e)
            {
                // https://stackoverflow.com/questions/14631923/xunit-net-cannot-find-assert-fail-and-assert-pass-or-equivalent
                Assert.True(false, "Error processing Kinesis Message :" + e.StackTrace);
            }
        }
