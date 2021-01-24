    public class Request
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Postcode { get; set; }
    }
    public class Response : Request
    {
    }
    public class EntryPointService
    {
        private readonly IService1 _service1;
        public EntryPointService(IService1 service1, IService2 service2, IService3 service3)
        {
            _service1 = service1;
            // Create your chain
            service1.RegisterNext(service2);
            service2.RegisterNext(service3);
            service3.RegisterNext(EndServiceHandler.Instance);
        }
        public Response Post(Request request)
        {
            // start your workflow
            var response =  _service1.TryToProcess(request);
            return response;
        }
    }
    public interface IChainProcessor
    {
        void RegisterNext(IChainProcessor next);
        Response TryToProcess(Request request);
    }
    public interface IService1: IChainProcessor
    {
    }
    public interface IService2: IChainProcessor
    {
    }
    public interface IService3 : IChainProcessor
    {
    }
    public class Service1: IService1
    {
        private IChainProcessor _next = EndServiceHandler.Instance;
        public void RegisterNext(IChainProcessor next)
        {
            _next = next;
        }
        public Response TryToProcess(Request request)
        {
            var canProcess = true; // Add your validation logic here.
            if (!canProcess) return _next.TryToProcess(request);
            
            try
            {
                // Do your service1 workflow.
                
                // DoSomething1(request);
                // DoSomething2(request);         
            }
            catch (ChainProcessException e)
            {
                // If something is wrong, Log and stop your workflow.
                return new Response(); // <= add your return info here.
            }
            return _next.TryToProcess(request);
        }
    }
    // Null object pattern: End chain element
    public class EndServiceHandler : IChainProcessor
    {
        public static EndServiceHandler Instance { get; } = new EndServiceHandler();
        public void RegisterNext(IChainProcessor next)
        {
            throw new InvalidOperationException(
                "Could not assign the next chain processor to the End of Workflow");
        }
        public Response TryToProcess(Request loanRequest)
        {
            // add here you invalid state.
            return new Response();
        }
    }
