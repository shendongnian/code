        var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
        var request = new PutObjectRequest
        {
            BucketName = "BucketName",
            Key = "KeyName",
            FilePath = "FilePath"
        };
        var response = client.PutObjectAsync(request).GetAwaiter().GetResult();
