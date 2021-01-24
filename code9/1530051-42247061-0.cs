    public RawImage displayTexture;
    
    private void GetObject()
    {
        ResultText.text = string.Format("fetching {0} from bucket {1}", SampleFileName, S3BucketName);
        Client.GetObjectAsync(S3BucketName, SampleFileName, (responseObj) =>
        {
            byte[] data = null;
            var response = responseObj.Response;
            if (response.ResponseStream != null)
            {
                using (StreamReader reader = new StreamReader(response.ResponseStream))
                {
                    using (var memstream = new MemoryStream())
                    {
                        var buffer = new byte[512];
                        var bytesRead = default(int);
                        while ((bytesRead = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                            memstream.Write(buffer, 0, bytesRead);
                        data = memstream.ToArray();
                    }
                }
    
                //Display Image
                displayTexture.texture = bytesToTexture2D(data);
            }
        });
    }
    
    public Texture2D bytesToTexture2D(byte[] imageBytes)
    {
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        return tex;
    }
