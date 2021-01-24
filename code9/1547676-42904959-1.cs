    static IAmazonS3 client;
    client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
    
    CopyObjectRequest request = new CopyObjectRequest()
    {
        SourceBucket      = bucketName,
        SourceKey         = objectKey,
        DestinationBucket = bucketName,
        DestinationKey    = destObjectKey
    };
    CopyObjectResponse response = client.CopyObject(request);
