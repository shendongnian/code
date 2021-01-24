    using System;
    using Amazon.S3;
    using Amazon.S3.Model;
    namespace MVCDragDrop
    {
        public class AmazonS3Uploader
        {
            private string bucketName = "xxxxx";
            private string keyName = "";
            private AmazonS3Client client;
            public AmazonS3Uploader()
            {
                client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            }
            public void UploadFile(string filePath)
            {
                
                try {
                    PutObjectRequest putRequest = new PutObjectRequest {
                        BucketName = bucketName,
                        Key = keyName,
                        FilePath = filePath,
                        ContentType = "plain/text"
                    };
                    PutObjectResponse response = client.PutObject(putRequest);
                }
                catch (AmazonS3Exception amazonS3Exception) {
                    if (amazonS3Exception.ErrorCode != null &&
                        (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                        ||
                        amazonS3Exception.ErrorCode.Equals("InvalidSecurity"))) {
                        throw new Exception("Check the provided AWS Credentials.");
                    } else {
                        //throw new Exception("Error occurred: " + amazonS3Exception.Message);
                    }
                }
            }
        }
    }
        
