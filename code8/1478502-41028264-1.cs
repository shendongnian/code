                AmazonS3Config cfg = new AmazonS3Config();
                cfg.RegionEndpoint = Amazon.RegionEndpoint.EUCentral1;// region endpoint
                string bucketName = "your bucket";
                AmazonS3Client s3Client = new AmazonS3Client("your access key", "your secret key", cfg);            
                string dataString ="your data ";
                MemoryStream data = new System.IO.MemoryStream(UTF8Encoding.ASCII.GetBytes(dataString));
                TransferUtility t = new TransferUtility(s3Client);
                t.Upload(data, bucketName, "testUploadFromTransferUtility.txt");
