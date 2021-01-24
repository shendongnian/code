    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        string jsonContent = await req.Content.ReadAsStringAsync();
        dynamic obj = JsonConvert.DeserializeObject<dynamic>(jsonContent);
        obj.MyProperty = "TEST";
        string extendedJSON = JsonConvert.SerializeObject(obj);
        return req.CreateResponse(HttpStatusCode.OK, extendedJSON);
    }
