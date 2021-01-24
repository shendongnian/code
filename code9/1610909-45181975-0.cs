    var databytes = System.Text.Encoding.UTF8.GetBytes(parameters.ToString());
    myWebRequest.ContentLength = databytes.Length;
    myWebRequest.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
    using (var stream = myWebRequest.GetRequestStream())
    {
        stream.Write(databytes, 0, databytes.Length);
    }
    
