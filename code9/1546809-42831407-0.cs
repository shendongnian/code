    public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
    {
        string jsonContent = await req.Content.ReadAsStringAsync();
        dynamic data = JsonConvert.DeserializeObject(jsonContent);
        return req.CreateResponse(HttpStatusCode.OK, $"doc title is {data.documentId}");
    }
