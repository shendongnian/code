    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAttribute : Attribute
    {
        public Type Service { get; }
        public ServiceAttribute(Type service)
        {
            Service = service;
        }
    }
