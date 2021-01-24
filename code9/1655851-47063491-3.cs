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
