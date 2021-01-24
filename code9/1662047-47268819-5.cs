    public class MyController : **ApiController**
    {
        [HttpGet]
        public Foo Index()
        {
            return new Foo{Name = "Bob"};
        }
    }
