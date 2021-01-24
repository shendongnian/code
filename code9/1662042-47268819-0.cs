    public class Foo
    {
        public string Name { get; set; }
    }
    public class MyController : System.Web.MvcController.Controller
    {
        [HttpGet]
        public Foo Index()
        {
            return new Foo{Name = "Bob"};
        }
    }
