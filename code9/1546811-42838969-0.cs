    #r "Newtonsoft.Json"
    using System;
    using System.Net;
    using Newtonsoft.Json;
    public class Input
    {
        public string DocumentId { get; set; }
    }
    public static HttpResponseMessage Run(Input input, 
                  HttpRequestMessage req, dynamic document, TraceWriter log)
    {
        if (document != null)
        {
            log.Info($"DocumentId: {document.text}");
            return req.CreateResponse(HttpStatusCode.OK);
        }
        else
        {
            return req.CreateResponse(HttpStatusCode.NotFound);
        }
    }
