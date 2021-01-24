 AmazonS3Config config = new AmazonS3Config();
                                string accessKey = WebConfigurationManager.AppSettings["AWSaccessKey"].ToString();
                                string secretKey = WebConfigurationManager.AppSettings["AWSsecretKey"].ToString();
                                config.ServiceURL = WebConfigurationManager.AppSettings["AWSServiceURL"].ToString();
                                string storageContainer = WebConfigurationManager.AppSettings["AWSBucketName"].ToString();
                                AmazonS3Client client2 = new AmazonS3Client(
                                    accessKey,
                                    secretKey,
                                    config
                                );```
                                Amazon.S3.AmazonS3 client3 = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretKey, config);
                                GetObjectRequest request1 = new GetObjectRequest();
                                request1.BucketName = storageContainer;
                                request1.WithBucketName(storageContainer);
                                request1.WithKey(originalfileName);
                                GetObjectResponse response1 = client3.GetObject(request1);
                                using (Stream responseStream = response1.ResponseStream)
                                {
                                    var bytes = ReadStream(responseStream);
                                    var download = new FileContentResult(bytes, "application/pdf");
                                    download.FileDownloadName = response1.Key;
                                    int c = filePath.Split('/').Length;
                                    byte[] fileBytes = download.FileContents;
                                    //return download;
                                    var fileEntry = new ZipEntry(filePath.Split('/')[c - 1].ToString());
                                    zipStream.PutNextEntry(fileEntry);
                                    zipStream.Write(fileBytes, 0, fileBytes.Length);
                                }
                         zipStream.Flush();
                        zipStream.Close();
