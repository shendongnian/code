    using (var stream = new MemoryStream())
    {
        // make sure that body is read from the beginning
        context.Request.Body.Seek(0, SeekOrigin.Begin);
        context.Request.Body.CopyTo(stream);
        string requestBody = Encoding.UTF8.GetString(stream.ToArray());
        // this is required, otherwise model binding will return null
        context.Request.Body.Seek(0, SeekOrigin.Begin);
    }
