    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    
    namespace FunctionApp
    {
        public static class Function1
        {
            [FunctionName("HttpTriggerCSharp")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
            {
                return req.CreateResponse(HttpStatusCode.OK, "Hello " + ClaimsPrincipal.Current.Identity.Name);
            }
        }
    }
