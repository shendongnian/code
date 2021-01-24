    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using System;
    
    namespace AzureFunctionTests
    {
        public static class WhereAmIRunning
        {
            [FunctionName("whereamirunning")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
            {
    			bool isLocal = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID"));
    
    			string response = isLocal ? "Function is running on local environment." : "Function is running on Azure.";
    
                return req.CreateResponse(HttpStatusCode.OK, response);
            }
        }
    }
