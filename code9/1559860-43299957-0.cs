     public static async Task<bool> PutS3Object(string bucket, string key, string content)
            {
                try
                {
                    using (var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
                    {
                        var request = new PutObjectRequest
                        {
                            BucketName = bucket,
                            Key = key,
                            ContentBody = content
                        };
                        var response = await client.PutObjectAsync(request);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in PutS3Object:" + ex.Message);
                    return false;
                }
            }
