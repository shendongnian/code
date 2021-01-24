    public class clsAwsS3
    {
        string accessKey { get; set; }
        string secretKey { get; set; }
        string bucket { get; set; }
        RegionEndpoint region { get; set; }
        IAmazonS3 client;
    
        public clsAwsS3(string strBucket, string strAccessKey, string strSecretKey, RegionEndpoint region)
        {
            this.bucket = strBucket;
            this.accessKey = strAccessKey;
            this.secretKey = strSecretKey;
            this.region = region;
            login();
        }
    
        private void login()
        {
            client = new AmazonS3Client(accessKey, secretKey, region);
        }
    
        public List<string> getItems(string strPrefix = "")
        {
            List<string> lstResult = new List<string>();
            ListObjectsV2Request listRequest;
    
            if (strPrefix == "")
                listRequest = new ListObjectsV2Request
                {
                    BucketName = bucket
                };
            else
                listRequest = new ListObjectsV2Request
                {
                    BucketName = bucket,
                    Prefix = strPrefix
                };
    
            ListObjectsV2Response listResponse;
    
            do
            {
                listResponse = client.ListObjectsV2(listRequest);
    
                foreach (S3Object awsObject in listResponse.S3Objects)
                    lstResult.Add(awsObject.Key);
    
                listRequest.ContinuationToken = listResponse.NextContinuationToken;
            } while (listResponse.IsTruncated);
    
            return lstResult;
        }
    
        public string downloadItem(string strItemKey, string strDestination)
        {
            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = bucket,
                Key = strItemKey
            };
    
            using (GetObjectResponse response = client.GetObject(request))
            {
                response.WriteResponseStreamToFile(strDestination);
            }
    
            return strDestination;
        }
    
        public void copyItem(string strItemKeySource, string strItemKeyDestination)
        {
            CopyObjectRequest copyRequest = new CopyObjectRequest
            {
                SourceBucket = bucket,
                SourceKey = strItemKeySource,
                DestinationBucket = bucket,
                DestinationKey = strItemKeyDestination
            };
    
            CopyObjectResponse copyResponse = client.CopyObject(copyRequest);
    
            if (copyResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Item has an error");
        }
    
        public void deleteItem(string strItemKey)
        {
            DeleteObjectRequest deleteObject = new DeleteObjectRequest
            {
                BucketName = bucket,
                Key = strItemKey
            };
    
            DeleteObjectResponse deleteResponse = client.DeleteObject(deleteObject);
        }
    }
