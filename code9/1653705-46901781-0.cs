     var _request = ((HttpApplication)sender).Request;
    
     var _bytes = new byte[_request.InputStream.Length];
     _request.InputStream.Read(_bytes, 0, _bytes.Length);
     _request.InputStream.Position = 0;
     string content = Encoding.ASCII.GetString(_bytes);
