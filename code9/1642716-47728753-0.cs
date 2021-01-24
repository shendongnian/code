    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
    readTextParams.Text = Convert.ToBase64String(encoding.GetBytes(readTextParams.Text.ToCharArray()));
    data = Newtonsoft.Json.JsonConvert.SerializeObject(readTextParams);
    byte[] bytes = encoding.GetBytes(data);
    request.ContentLength = bytes.Length;
    using (Stream requestStream = request.GetRequestStream())
    {
          requestStream.Write(bytes, 0, bytes.Length);
    }
