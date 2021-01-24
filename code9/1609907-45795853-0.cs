    public class CustomHttpControllerSelector : DefaultHttpControllerSelector
        {
            private readonly HttpConfiguration _configuration;
            private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;
 
        /// <summary>
        /// custom http controllerselector
        /// </summary>
        /// <param name="config"></param>
        public CustomHttpControllerSelector(HttpConfiguration config) : base(config)
        {
            _configuration = config;
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
        }
 
        /// <summary>
        /// GetControllerMapping
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }
 
        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            var controllers = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);
 
            IAssembliesResolver assembliesResolver = _configuration.Services.GetAssembliesResolver();
            IHttpControllerTypeResolver controllersResolver = _configuration.Services.GetHttpControllerTypeResolver();
            ICollection<Type> controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver);
 
            foreach (Type t in controllerTypes)
            {
                var controllerName = t.Name.Remove(t.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);
 
                //Remove Core API Controller and add the Plugin API controller.
                if (controllers.Keys.Contains(controllerName) && t.Namespace.Contains("Plugin"))
                {
                    controllers.Remove(controllerName);
                }
                if (!controllers.Keys.Contains(controllerName))
                {
                    controllers[controllerName] = new HttpControllerDescriptor(_configuration, t.Nam`enter code here`e, t);
                }
            }
            return controllers;
        }
    }
