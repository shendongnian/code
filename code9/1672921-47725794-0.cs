    public class BaseController : ApiController
    {
        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {            
            try
            {
                HttpResponseMessage response = await base.ExecuteAsync(controllerContext, cancellationToken);
                if (!response.IsSuccessStatusCode) // or if(response.StatusCode == HttpStatusCode.BadRequest) 
                {
                    //log here 
                }
                return response;
            }
            catch(Exception ex)
            {
                return await InternalServerError(ex).ExecuteAsync(cancellationToken);
            }            
        }
    }  
