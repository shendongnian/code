    public class MyControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            if (controllerType == typeof (ValuesController))
            {
                var pathAndQuery = request.RequestUri.PathAndQuery;
                IAccountsService svc;
                if (pathAndQuery.StartsWith("/api2"))
                    svc = new Service2();
                else if (pathAndQuery.StartsWith("/api"))
                    svc = new Service1();
                else 
                    throw new Exception("Unexpected Url");
                return new ValuesController(svc);
            }
            throw new Exception("Unexpected Controller Type");
        }
    }
