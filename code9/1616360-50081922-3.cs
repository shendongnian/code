     public void WritingAnObject(string keyName, MemoryStream fileToUpload)
        {
            try
            {
                TransferUtilityUploadRequest fileTransferUtilityRequest = new 
                TransferUtilityUploadRequest
                {
                    StorageClass = S3StorageClass.ReducedRedundancy,
                    CannedACL = S3CannedACL.Private
                };
                fileTransferUtility.Upload(fileToUpload, _bucketName, keyName);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                //your error handling here
            }
        }
