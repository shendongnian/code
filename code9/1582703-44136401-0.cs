    public class CustomControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            // Your logic to return an IHttpController
            // You can use a DI Container or you custom logic
        }
    }
