    public class AWSFileUploadService : IFileUploadService {
        private readonly IAmazonS3 _amazonS3Client;
        private readonly TransferUtility _fileTransferUtility;
        public AWSFileUploadService(IAmazonS3 s3) {
            _amazonS3Client = s3;
            //Not sure about this next class but should consider abstracting it as well.
            _fileTransferUtility = new TransferUtility(_amazonS3Client);
        }
        public bool DoSomethingWithKinesisEvent(KinesisEvent kinesisEvent) {
            //code removed for brevity
            return true;
        }
    }
