    public static HttpWebResponse PostMethod(string postedData, string postUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            UTF8Encoding encoding = new UTF8Encoding();
            var bytes = encoding.GetBytes(postedData);
            //request.ContentType = "application/javascript";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentType = "application/json; charset=utf-8";
            //request.ContentType = "application/json";
            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = bytes.Length;
            using (var newStream = request.GetRequestStream())
            {
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }
            return (HttpWebResponse)request.GetResponse();
        }
