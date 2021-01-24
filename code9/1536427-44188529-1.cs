    public void Navigate(string url, byte[] postDataBytes, string contentType)
        {
            IFrame frame = this.GetMainFrame();
            IRequest request = frame.CreateRequest();
            request.Url = url;
            request.Method = "POST";
            // Could use postData.AddData(System.Text.Encoding.ASCII.GetString(postDataBytes), Encoding.ASCII) etc. to do
            // the following but I think converting without using an encoding is safer. 
            string bytesAsString = new string(
                postDataBytes.Select(b => (char)b).ToArray()
            );
            request.InitializePostData();
            request.PostData.AddData(bytesAsString);
            NameValueCollection headers = new NameValueCollection();
            headers.Add("Content-Type", contentType );
            request.Headers = headers;
            frame.LoadRequest(request);
        }
