    ...
    var key = (string)mbS3Credentials["key"];
    var sessionToken = (string)mbS3Credentials["sessionToken"];
    ...
    var amazonS3Uploader = new AmazonS3Uploader(accessKeyId, secretAccessKey, sessionToken, url);
    ...
    
    
     public AmazonS3Uploader(string accessKeyId, string secretAccessKey, string sessionToken, string serviceUrl)
            {
                var s3Config = new AmazonS3Config
                {
                    ServiceURL = serviceUrl,
                    RegionEndpoint = RegionEndpoint.USEast1,
                    ForcePathStyle = true,
                };
                _s3Client = new AmazonS3Client(accessKeyId, secretAccessKey, sessionToken, s3Config);
            }
    
    public void UploadFile(string filePath, string s3BucketName, string key, string newFileName, bool deleteLocalFileOnSuccess)
            {
                //save in s3
                var s3PutRequest = new PutObjectRequest
                {
                    FilePath = filePath,
                    BucketName = s3BucketName,
                    Key = key,
                    CannedACL = S3CannedACL.PublicRead
                };
    
                //key - new file name
                //if (!string.IsNullOrWhiteSpace(newFileName))
                //{
                //    s3PutRequest.Key = newFileName;
                //}
