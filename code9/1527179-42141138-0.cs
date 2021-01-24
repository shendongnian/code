    //Code for gzip the content and add header
    HttpContext.Current.Response.Filter = new System.IO.Compression.GZipStream(
                    HttpContext.Current.Response.Filter, 
                    System.IO.Compression.CompressionMode.Compress);
    HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
