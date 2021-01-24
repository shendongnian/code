    private void GetObject()
    {
        ResultText.text = string.Format("fetching {0} from bucket {1}", SampleFileName, S3BucketName);
        Client.GetObjectAsync(S3BucketName, SampleFileName, (responseObj) =>
        {
            byte[] data = null;
            var response = responseObj.Response;
            Stream input = response.ResponseStream;
    
            if (response.ResponseStream != null)
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    data = ms.ToArray();
                }
    
                //Display Image
                displayTexture.texture = bytesToTexture2D(data);
            }
        });
    }
