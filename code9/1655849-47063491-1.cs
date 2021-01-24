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
