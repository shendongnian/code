    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace FunctionApp1
    {
        public static class Function1
        {
            [FunctionName("Function2")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "qotd/{format:alpha?}")]HttpRequestMessage req, string format, TraceWriter log)
            {
               
                if (format == "json")
                {
                    return req.CreateResponse(HttpStatusCode.OK, "aaa", "application/json");
                }
                else
                {
                    return req.CreateResponse(HttpStatusCode.OK, "aaa", "text/plain");
                }
            }
        }
    }
