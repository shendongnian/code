    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    
    namespace MyFunctions
    {
        public static class MyFunctionsOperations
        {
            [FunctionName("MyFunctionsOperations")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
            {
                log.Info("C# HTTP trigger function processed a request.");
                var headers = req.Headers;
                string collection = headers.GetValues("collection").First();   //getting parameter from header
                
                CosmosdbOperation obj = new CosmosdbOperation();
                dynamic data = await req.Content.ReadAsAsync<object>();  //getting body content
                Boolean response = await obj.MyFunctionExecution(data.ToString(), collection);
    
                return (response)
                    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a proper argument in the request body")
                    : req.CreateResponse(HttpStatusCode.OK, "Operation successfully executed..");
            }
        }
    }
