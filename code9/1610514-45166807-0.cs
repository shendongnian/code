    [RoutePrefix("api/v1/clients")]
    public class ClientsController : ApiController
    {
        // GET: api/Clients/5
        [ResponseType(typeof(string))]
        [Route("{id:int}/emailid"),HttpGet]
        public IHttpActionResult GetClientEmailId(int id)
        {
            //code
        }     
    }
