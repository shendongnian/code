     string item = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" +
      "<request>" +
      "<Username>admin</Username>" +
      "<Password>" + password + "</Password>" +
      "<password_type>4</password_type>" +
      "</request> ";
    var request = (HttpWebRequest)WebRequest.Create("http://192.168.8.1/api/user/login");
    request.Method = "POST";
    request.Headers["_RequestVerificationToken"]= Token;
    request.Headers["Cookie"] = Sess;
    byte[] bytes = Encoding.UTF8.GetBytes(item);
    request.ContentType = "application/xml";
    request.ContentLength = bytes.Length;
    Stream streamreq = request.GetRequestStream();
    streamreq.Write(bytes, 0, bytes.Length);
    streamreq.Close();
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    {
        var result = reader.ReadToEnd();
    }
