    using System.Net;
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, string inputBlob, TraceWriter log)
    {
        log.Info("Blob content: " + inputBlob);
        return req.CreateResponse(HttpStatusCode.OK, inputBlob);
    }
