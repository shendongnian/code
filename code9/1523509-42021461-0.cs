    string Url = "http://localhost:6740";
    HttpWebRequest request = HttpWebRequest.Create(Url) as HttpWebRequest;
    string result = null;
    //POST method here.
    request.Method = "post";
    request.ContentType = "application/x-www-form-urlencoded";
 
    //Parameters here.
    string param = "para1=data1&para2=data2";
    //Maybe you need unicode or other encoding...
    byte[] bs = Encoding.ASCII.GetBytes(param);
    using (Stream reqStream = request.GetRequestStream())
    {
        reqStream.Write(bs, 0, bs.Length);
    }
 
    using (WebResponse response = request.GetResponse())
    {
        StreamReader sr = new StreamReader(response.GetResponseStream());
        result = sr.ReadToEnd();
        sr.Close();
    }
