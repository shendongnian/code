    #r "Newtonsoft.Json"
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using Newtonsoft.Json.Linq;
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        dynamic data = await req.Content.ReadAsAsync<object>();
        JArray symbols = data?.symbols;
        return symbols == null
            ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass symbols in the body")
            : req.CreateResponse(HttpStatusCode.OK, symbols, JsonMediaTypeFormatter.DefaultMediaType);
    }
