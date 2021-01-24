    byte[] binary = Encoding.Unicode.GetBytes(content);
    httpWebRequest.ContentLength = binary.Length;
    using (System.IO.Stream requestStream = httpWebRequest.GetRequestStream())
    {
         requestStream.Write(binary, 0, binary.Length);
    }
