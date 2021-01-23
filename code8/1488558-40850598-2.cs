    [RoutePrefix("Api/My")]
    public class MyController : ApiController
    {
        [HttpGet]
        [Route("foo/{id:int}")]
        public IList<string> GetFoo(int id)
        {
            return new string[] {"Foo1-" + id, "Foo1-" + id};
        }
    
        [HttpGet]
        [Route("bar/{id:int}")]
        public IList<string> GetBar(int id)
        {
            return new string[] {"Bar1-" + id, "Bar1-" + id};
        }
    }
