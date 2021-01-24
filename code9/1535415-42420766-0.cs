    [RoutePrefix("api")]
    public class ProductController : ApiController
    {
        [HttpGet, Route("product/{id?}")]
        public async Task<HttpResponseMessage> GetProduct([FromUri] string param1 = null, [FromUri] string param2 = null, Guid? id = null)
        {
            ...     
        }
    }
