    [OperationContract]
    [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    public Stream GetJSON()
    {
        WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
        WebOperationContext.Current.OutgoingResponse.Headers["Content-Encoding"] = "gzip";
        Dictionary<string, string> resultDict = new Dictionary<string, string>();
        return Compress(SerializeToJSON(resultDict));
    }
    
    public static Stream SerializeToJSON(object value)
    {
        var resultStream = new MemoryStream();
        using (var jsonStream = new MemoryStream())
        using (var writer = new StreamWriter(jsonStream))
        using (var jsonWriter = new JsonTextWriter(writer))
        {
            var jsonSer = new JsonSerializer();
            jsonSer.Formatting = Formatting.None;
            jsonSer.Serialize(jsonWriter, value);
            jsonWriter.Flush();
            resultStream = new MemoryStream(jsonStream.ToArray());
        }
        return resultStream;
    }
    
    public static Stream Compress(Stream plainStream)
    {
        var resultStream = new MemoryStream();
        using (var compressedStream = new MemoryStream())
        using (var compressor = new GZipStream(compressedStream, CompressionMode.Compress))
        {
            plainStream.CopyTo(compressor);
            compressor.Close();
            resultStream = new MemoryStream(compressedStream.ToArray());
        }
        return resultStream;
    }
