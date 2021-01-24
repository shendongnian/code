    public class FooController : Controller
    {
        public IEnumerable<Foo> GetAll( 
            string Filter, 
            string Whatever, 
            ..., 
            int pageNumber = 1, 
            int pageSize = 20 ) 
        { ... }
    }
