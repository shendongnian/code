    public class OutputsController : ApiController
    {
        public async Task<IHttpActionResult> Get(string id)
        {
            ConfigurationManager cm = new ConfigurationManager();
            
            var output = await cm.GetOuputs(id);
    
            return Ok(output); // or NotFound();
        }
