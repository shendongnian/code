    public static async Task CallRequestsAsync(string data1, string data2)
    {
        var cookie = new CookieContainer();
        var postData = Parameters[23] + data1 +
                        Parameters[24] + data2;
        HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(Parameters[25]);
        getRequest.Accept = Parameters[26];
        getRequest.KeepAlive = true;
        getRequest.Referer = Parameters[27];
        getRequest.CookieContainer = cookie;
        getRequest.UserAgent = Parameters[28];
        getRequest.Method = WebRequestMethods.Http.Post;
        getRequest.AllowWriteStreamBuffering = true;
        getRequest.ProtocolVersion = HttpVersion.Version10;
        getRequest.AllowAutoRedirect = false;
        getRequest.ContentType = Parameters[29];
        getRequest.ReadWriteTimeout = 5000;
        getRequest.Timeout = 5000;
        getRequest.Proxy = null;
        byte[] byteArray = Encoding.ASCII.GetBytes(postData);
        getRequest.ContentLength = byteArray.Length;
        Stream newStream =await getRequest.GetRequestStreamAsync(); //open connection
        await newStream.WriteAsync(byteArray, 0, byteArray.Length); // Send the data.
        newStream.Close();
        HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
        if (getResponse.Headers["Location"] == Parameters[30])
        {
            //These are simple get requests to retrieve the source code using the same format as above.
            //I need to preserve the cookie
            GetRequets(data1, data2, Parameters[31], Parameters[13], cookie);
            GetRequets(data1, data2, Parameters[32], Parameters[15], cookie);
        }
    }
