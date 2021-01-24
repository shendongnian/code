    public sealed class MyControllerActivator : IHttpControllerActivator
    {
        private readonly Container container;
        private readonly IHttpControllerActivator original;
        public MyControllerActivator(Container container, IHttpControllerActivator original)
        {
            this.container = container;
            this.original = original;
        }
        public IHttpController Create(
            HttpRequestMessage req, HttpControllerDescriptor desc, Type type)
        {
            if (type == typeof(ILGTWebApiController))
                return (IHttpController)this.container.GetInstance(type);
            return this.original.Create(req, desc, type);
        }
    }
