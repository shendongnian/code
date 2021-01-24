    public class FooService<T>
    {
        private readonly IStringLocalizerFactory _factory;
        public FooService(IStringLocalizerFactory factory)
        {
            _factory = factory;
        }
        public IStringLocalizer GetLocalizer()
        {
            var type = typeof(FooService<>);
            string assemblyName = type.GetTypeInfo().Assembly.GetName().Name;
            string typeName = type.Name.Remove(type.Name.IndexOf('`'));
            string baseName = (type.Namespace + "." + typeName).Substring(assemblyName.Length).Trim('.');
            var localizer = _factory.Create(baseName, assemblyName);
            
            return localizer;
        }
    }
