    public class FooController : ApiController
    {
        public IStore Store { get; set; }
        
        public FooController(IStore store)
        {
            Store = store;
        }
    }
