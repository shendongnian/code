        var s3Config = new AmazonS3Config
        {
            ServiceURL = Constants.AmazonS3ServiceUrl, 
            RegionEndpoint = Amazon.RegionEndpoint.EUWest1
        };
            
        string accessKeyId = Constants.AmazonAccessKeyId;
        string secretAccessKey = Constants.AmazonSecretAccessKey;
            
        var config = new AwsS3Config(){AmazonS3BucketName = Constants.AmazonS3BucketName};
        var client = new AmazonS3Client(accessKeyId, secretAccessKey, s3Config);
