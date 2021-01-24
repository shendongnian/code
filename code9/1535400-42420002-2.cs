        string formUrl = "url";
        string formParams = string.Format("params");
        string cookieHeader;
        WebRequest req = WebRequest.Create(formUrl);
        req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        req.Method = "POST";
        byte[] bytes = Encoding.ASCII.GetBytes(formParams);
        req.ContentLength = bytes.Length;
        using (Stream os = req.GetRequestStream())
        {
            os.Write(bytes, 0, bytes.Length);
        }
        WebResponse resp = req.GetResponse();
        cookieHeader = resp.Headers["Set-cookie"];
        string pageSource;
        string getUrl = "link to csv file";
        WebRequest getRequest = WebRequest.Create(getUrl);
        getRequest.Headers.Add("Cookie", cookieHeader);
        WebResponse getResponse = getRequest.GetResponse();
        using (StreamReader sr = new 
        using (Stream output = File.OpenWrite("filename.csv"))
        using (Stream input = getResponse.Response.GetResponseStream())
        {
             input.CopyTo(output);
        }
