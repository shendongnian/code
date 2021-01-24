    public class BaseController : ApiController
    {
        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await base.ExecuteAsync(controllerContext, cancellationToken);
    
                return response;
            }
            catch (HttpResponseException ex)
            {               
                if (ex.Response.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    //Logging implementation
                }
                return Request.CreateErrorResponse(ex.Response.StatusCode, ex.Message);
            }   
        }            
    }
