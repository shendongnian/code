    public class AWSLambdaFileProcessingService {
        private IFileUploadService _fileUploadService;
        [LambdaSerializer(typeof(JsonSerializer))]
        public void ProcessKinesisMessageById(KinesisEvent kinesisEvent, ILambdaContext context) {
            Console.WriteLine("Processing Kinesis Request");
            _fileUploadService = FileUploadService.Value;
            // some sort of processing
            _fileUploadService.DoSomethingWithKinesisEvent(kinesisEvent);
        }
        public static Lazy<IFileUploadService> FileUploadService = new Lazy<IFileUploadService>(() => {
            var env = new SystemEnvironmentService();
            var s3 = new AmazonS3Client(
                env.GetEnvironmentVariable("AWS_S3_KEY"),
                env.GetEnvironmentVariable("AWS_S3_SECRET_KEY")
            );
            var service = new AWSFileUploadService(s3);
            return service;
        });
    }
