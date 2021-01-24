        static IAmazonS3 client;
        static TransferUtility fileTransferUtility;
        public S3Uploader(string accessKeyId, string secretAccessKey,string bucketName)
        {
            _bucketName = bucketName;
            var credentials = new BasicAWSCredentials(accessKeyId, secretAccessKey);
            client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
            fileTransferUtility = new TransferUtility(client);
        }
