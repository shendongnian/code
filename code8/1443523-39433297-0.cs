    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
    response.Content = new PushStreamContent((stream, content, context) =>
    {
        using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
        using (JsonTextWriter jtw = new JsonTextWriter(sw))
        {
            JsonSerializer ser = new JsonSerializer();
            ser.Serialize(jtw, hugeObject);
        }
    }, "application/json");
