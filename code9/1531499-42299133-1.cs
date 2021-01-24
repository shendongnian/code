    AWSCredentials credentials = new BasicAWSCredentials(accessKey, secretKey);
    AmazonS3Config config = new AmazonS3Config();
    config.ServiceURL = "s3.amazonaws.com";
    config.RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName("us-east-1");
    client = new AmazonS3Client(credentials, config);
