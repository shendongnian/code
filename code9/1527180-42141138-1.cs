    //Code for gzip the content and add header
    context.Response.Filter = new System.IO.Compression.GZipStream(
                    context.Response.Filter, 
                    System.IO.Compression.CompressionMode.Compress);
    context.Response.AppendHeader("Content-Encoding", "gzip");
