    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpPost]
        [Route("takeit")] //Matches POST api/test/takeit
        public IHttpActionResult TakeIt([FromBody]MyObject o){
            Console.Write(o.ToString());
            return Ok();
        }
    }
