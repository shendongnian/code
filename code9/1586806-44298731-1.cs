using System;
using System.Collections.Generic;
using Amazon.S3;
using Amazon.S3.Model;
namespace s3.amazon.com.docsamples
{
    class CopyObjectUsingMPUapi
    {
        static string sourceBucket    = "*** Source bucket name ***";
        static string targetBucket    = "*** Target bucket name ***";
        static string sourceObjectKey = "*** Source object key ***";
        static string targetObjectKey = "*** Target object key ***";
        static void Main(string[] args)
        {
            IAmazonS3 s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            // List to store upload part responses.
            List<UploadPartResponse> uploadResponses = new List<UploadPartResponse>();
            List<CopyPartResponse> copyResponses = new List<CopyPartResponse>();
            InitiateMultipartUploadRequest initiateRequest =
                   new InitiateMultipartUploadRequest
                       {
                           BucketName = targetBucket,
                           Key = targetObjectKey
                       };
            InitiateMultipartUploadResponse initResponse =
                s3Client.InitiateMultipartUpload(initiateRequest);
            String uploadId = initResponse.UploadId;
            try
            {
                // Get object size.
                GetObjectMetadataRequest metadataRequest = new GetObjectMetadataRequest
                    {
                         BucketName = sourceBucket,
                         Key        = sourceObjectKey
                    };
                GetObjectMetadataResponse metadataResponse = 
                             s3Client.GetObjectMetadata(metadataRequest);
                long objectSize = metadataResponse.ContentLength; // in bytes
                // Copy parts.
                long partSize = 5 * (long)Math.Pow(2, 20); // 5 MB
                long bytePosition = 0;
                for (int i = 1; bytePosition < objectSize; i++)
                {
                    CopyPartRequest copyRequest = new CopyPartRequest
                        {
                            DestinationBucket = targetBucket,
                            DestinationKey = targetObjectKey,
                            SourceBucket = sourceBucket,
                            SourceKey = sourceObjectKey,
                            UploadId = uploadId,
                            FirstByte = bytePosition,
                            LastByte = bytePosition + partSize - 1 >= objectSize ? objectSize - 1 : bytePosition + partSize - 1,
                            PartNumber = i
                        };
                    copyResponses.Add(s3Client.CopyPart(copyRequest));
                    bytePosition += partSize;
                }
                CompleteMultipartUploadRequest completeRequest =
                      new CompleteMultipartUploadRequest
                          {
                              BucketName = targetBucket,
                              Key = targetObjectKey,
                              UploadId = initResponse.UploadId
                          };
                completeRequest.AddPartETags(copyResponses);
                CompleteMultipartUploadResponse completeUploadResponse = s3Client.CompleteMultipartUpload(completeRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Helper function that constructs ETags.
        static List<PartETag> GetETags(List<CopyPartResponse> responses)
        {
            List<PartETag> etags = new List<PartETag>();
            foreach (CopyPartResponse response in responses)
            {
                etags.Add(new PartETag(response.PartNumber, response.ETag));
            }
            return etags;
        }
    }
}
