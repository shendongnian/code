        ListObjectsRequest request = new ListObjectsRequest()
        {
            BucketName = "Your Bucket name",
            Delimiter = "/",
            Prefix = "location"
        };
        public bool CheckFile(ListObjectsRequest request)
        {
            bool res = false;
            try
            {
                ListObjectsResponse response = s3client.ListObjects(request);
                if (response.S3Objects != null && response.S3Objects.Count > 0)
                {
                    S3Object o = response.S3Objects.Where(x => x.Size != 0 && x.LastModified > DateTime.Now.AddHours(-24)).FirstOrDefault();
                    if (o != null)
                    {
                        //you can use thes fields
                        // o.Key; //o.Size, //o.LastModified
                        res = true;
                    }
                   
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }
