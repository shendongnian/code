    public static byte[] MakeRequest(
        string method, 
        string uri, 
        string username, 
        string password, 
        byte[] requestBody = null)
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
        request.Credentials = new NetworkCredential(username, password);
        request.Method = method;
        //Other request settings (e.g. UsePassive, EnableSsl, Timeout set here)
        
        if (requestBody != null)
        {
            using (MemoryStream requestMemStream = new MemoryStream(requestBody))
            using (Stream requestStream = request.GetRequestStream())
            {
                requestMemStream.CopyTo(requestStream);
            }
        }
        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        using (MemoryStream responseBody = new MemoryStream())
        {
            response.GetResponseStream().CopyTo(responseBody);
            return responseBody;
        }
    }
