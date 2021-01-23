    public class DummiesController : ApiController
    {
        [HttpGet()]
        [Route("api/dummies")]
        public IHttpActionResult Get()
        {
            return this.Ok(new[] {new Dummy(), new Dummy()});
        }
            
        [HttpGet()]
        [Route("api/dummies/{id}")]
        public IHttpActionResult GetById(int id)
        {
            return this.Ok(new Dummy());
        }
            
        [HttpPost]
        [Route("api/dummies")]
        public IHttpActionResult Post(Dummy dummy)
        {
            int id = 1;
            return this.Created($"api/dummies/{id}", dummy);
        }
    }
