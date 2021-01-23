    app.Use(async (http, next) =>
    {
    //remember previous body
    var currentBody = http.Response.Body;
    using (var memoryStream = new MemoryStream())
    {
        //set the current response to the memorystream.
        http.Response.Body = memoryStream;
        await next();
        string requestId = Guid.NewGuid().ToString();
        //reset the body as it gets replace due to https://github.com/aspnet/KestrelHttpServer/issues/940
        http.Response.Body = currentBody;
        memoryStream.Seek(0, SeekOrigin.Begin);
        //build our content wrappter.
        var content = new StringBuilder();
        content.AppendLine("{");
        content.AppendLine("  \"RequestId\":\"" + requestId + "\",");
        content.AppendLine("  \"StatusCode\":" + http.Response.StatusCode + ",");
        content.AppendLine("  \"Result\":");
        //add the original content.
        content.AppendLine(new StreamReader(memoryStream).ReadToEnd());
        content.AppendLine("}");
        await http.Response.WriteAsync(content.ToString());
    }
    });
