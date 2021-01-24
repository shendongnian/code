    public class InfoController : ApiController
    {
        // Without custom header
        public IHttpActionResult MyMethod(..)
        {
            var myObject= GetMyResult();
            return Ok(myObject);
        }
    
        // With custom header
        public IHttpActionResult MyMethod(..)
        {
            var myObject = GetMyResult();
            
            // inspired from https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/content-negotiation#how-content-negotiation-works
            var negotiator = Configuration.Services.GetContentNegotiator();
            var result = negotiator.Negotiate(typeof(TypeOfMyObject), Request, Configuration.Formatters);
            var msg = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<TypeOfMyObject>(myObject, result.Formatter,result.MediaType.MediaType)
            };
    
            msg.Headers.Add("MyCustomHeader", "MyCustomHeaderValue");
            return ResponseMessage(msg);
        }
    }
