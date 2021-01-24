    public class ServiceWorker
    {
        IService _service;
    
        public ServiceWorker(string name, string id, IService service) 
        { 
            _service = service
        }
    }
    
    public class ServiceWorkerFacade
    {
        ServiceWorker imp;
    
        public ServiceWorkerFacade(string name, string id) 
        { 
            imp =
                new ServiceWorker(
                    name,
                    id,
                    new FooService(
                        new BarService(),
                        new BazService());
        }
    }
    
    public class Caller
    {
        // No way to change this. 
        var serviceWorker = new ServiceWorkerFacade(name, id);
    }
