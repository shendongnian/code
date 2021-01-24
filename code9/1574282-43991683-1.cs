            GetObjectRequest getRequest = new GetObjectRequest();
            getRequest.BucketName = "your bucket name";
            getRequest.Key = "your file key name";
            getRequest.ServerSideEncryptionCustomerMethod = ServerSideEncryptionCustomerMethod.AES256;
            getRequest.ServerSideEncryptionCustomerProvidedKey = CustomerKey;
            getRequest.ServerSideEncryptionCustomerProvidedKeyMD5 = CustomerKeyMD5;
            using (GetObjectResponse response = s3Client.GetObject(getRequest))
            {
                using (Stream test = response.ResponseStream)
                { 
                    using(FileStream file = new FileStream(@"d:\SmallData\result\test.pdf", FileMode.OpenOrCreate))
                    {
                        CopyStream(test, file);
                    }
                }
            }
