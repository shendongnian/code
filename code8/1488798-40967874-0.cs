    main()
    {
        HttpWebRequest request;
        HttpWebResponse response = null;
        string url = "*****URL*****";
        string path = @"..\test.csv";
        Random rand = new Random();
        string contentType = "text/csv";
        byte[] header = RequestHeader(boundary,path,nameValue, contentType);
        request = (HttpWebRequest)WebRequest.Create(url);
        RequestParameters(header, path, boundary);
        response = (HttpWebResponse)request.GetResponse();
    }
    private byte[] RequestHeader(string boundary, string path, string nameValue, string contentType)
    {
        return System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"" + nameValue + "\"; filename=\"" + System.IO.Path.GetFileName(path) + "\"\r\nContent-Type:" + contentType + "\r\n\r\n");
    }
    private void RequestParameters(byte[] header, string path, string boundary)
    {
        byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
        request.Method = "post";
        request.KeepAlive = true;
        request.ContentType = "multipart/form-data" + boundary;
        data_stream = request.GetRequestStream();
        data_stream.Write(header, 0, header.Length);
        byte[] file_bytes = System.IO.File.ReadAllBytes(path);
        data_stream.Write(file_bytes, 0, file_bytes.Length);
        data_stream.Write(trailer, 0, trailer.Length);
        data_stream.Close();
    }
