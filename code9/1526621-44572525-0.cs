        public class ServiceActivator : IHttpControllerActivator
        {
            private IKernel kernel;
            
            public ServiceActivator(HttpConfiguration configuration, IKernel kernel)
            {
                this.kernel = kernel;
            }
            public IHttpController Create(
                HttpRequestMessage request,
                HttpControllerDescriptor controllerDescriptor,
                Type controllerType)
            {
                var controller = kernel.Get(controllerType) as IHttpController;
                return controller;
            }
        }
