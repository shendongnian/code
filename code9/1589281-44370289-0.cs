        public class TestController : Controller
        {
            private IService _myService;
    
            public TestController (IServices myService)
            {
                _myService = service;
            }
     
            public TestController() : this (new ServiceImplementation)
            {
                
            }
        }
