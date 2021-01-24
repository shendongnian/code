    [Route("/customers", "GET")]
    class GetCustomer { ... }
    
    [Route("/customers")]
    class StoreCustomer { ... }
    
    public class MyServices : Service
    {
        public object Get(GetCustomer request) => ...;
    
        public object Any(StoreCustomer request) => ...;
    }
