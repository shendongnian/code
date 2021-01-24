    using Amazon.Runtime;
    using Amazon.Runtime.CredentialManagement;
    
    using Amazon.S3;
    using Amazon.SQS;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var store = new CredentialProfileStoreChain(@"C:\aws_service_credentials\credentials");
    
                store.TryGetAWSCredentials("clientSQS", out AWSCredentials clientSQSCredentials);
                var sqsClient = new AmazonSQSClient(clientSQSCredentials, Amazon.RegionEndpoint.USEast1);
    
                store.TryGetAWSCredentials("clientS3", out AWSCredentials clientS3Credentials);
                var s3Client = new AmazonS3Client(clientS3Credentials, Amazon.RegionEndpoint.USEast1);
            }
        }
    }
