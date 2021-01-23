    public static byte[] Compress(string s)
    {
        var b = Encoding.UTF8.GetBytes(s);
        var ms = new MemoryStream();
        using (GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress))
        {
            zipStream.Write(b, 0, b.Length);
            zipStream.Flush(); //Doesn't seem like Close() is available in UWP, so I changed it to Flush(). Is this the problem?
        }
        
        // we create the data array here once the GZIP stream has been disposed
        var data	= ms.ToArray();
        ms.Dispose();
        return data;
    }
