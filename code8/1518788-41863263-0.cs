    public class FooController : ApiController
        {
            public IHttpActionResult Get()
            {
                var foo = "foo";
                return Ok(foo);
            }
        }
    
