            public static bool wfFileExists(String pBucketName, String pKeyName, String pCryptoKey) {
            bool retVal = false;
            try {
                using (var lS3Client = new AmazonS3Client()) {
                    GetObjectMetadataRequest request = new GetObjectMetadataRequest {
                        BucketName = pBucketName,
                        Key = pKeyName,
                        ServerSideEncryptionCustomerMethod = ServerSideEncryptionCustomerMethod.AES256,
                        ServerSideEncryptionCustomerProvidedKey = pCryptoKey,
                    };
                    GetObjectMetadataResponse lMetaData = lS3Client.GetObjectMetadata(request);
                    // If an error is not thrown, we found the metadata.
                    retVal = true;
                }
            }
            catch (AmazonS3Exception s3Exception) {
                Console.WriteLine(s3Exception.Message,
                                  s3Exception.InnerException);
                if (s3Exception.ErrorCode != "NotFound") {
                    throw (s3Exception);
                }
            }
            catch (Exception e) {
                throw (e);
            }
            return retVal;
        }
