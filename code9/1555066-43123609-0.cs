    public class CompositionRoot : IHttpControllerActivator
    {
        private readonly IContainer _container;
        public CompositionRoot(IContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            _container = container;
        }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController) _container.GetInstance(controllerType);
            return controller;
        }
