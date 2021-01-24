    #r "Newtonsoft.Json"
    using System.Net;
    using Newtonsoft.Json;
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, 
     TraceWriter log)
    {
        log.Info("C# HTTP trigger function processed a request.");
        // Get request body
        string json = await req.Content.ReadAsStringAsync();
        log.Info($"Read json: {json}");
         dynamic data = JsonConvert.DeserializeObject(json);
        
        string deserialized = data?.ToString();
        return req.CreateResponse(HttpStatusCode.OK, deserialized);
    }
