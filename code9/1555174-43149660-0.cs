    public class ControllerFactory : DefaultControllerFactory
    {
        private static volatile Dictionary<string, Lookup<string, Type>> _ctcache;
        private static readonly object Lock = new object();
        private static Dictionary<string, Lookup<string, Type>> ControllerTypeCache
        {
            get
            {
                if (_ctcache != null)
                    return _ctcache;
                FillTypeCache();
                return _ctcache;
            }
        }
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var routeData = requestContext.RouteData;
            //This comes from the DefaultControllerFactory.  I don't use attribute routing.
            if (routeData?.Values.ContainsKey("MS_DirectRouteMatches") ?? false)
                throw new NotImplementedException();
            object obj = null;
            if (!(routeData?.DataTokens.TryGetValue("Namespaces", out obj) ?? false))
                return null;
            var namespaces = (obj as IEnumerable<string>)?.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
            if ((namespaces == null) || !namespaces.Any())
                return null;
            return ControllerTypeCache[controllerName].SingleOrDefault(x => namespaces.Any(y => IsNamespaceMatch(y, x.Key)))?
                .SingleOrDefault();
        }
        private static void FillTypeCache()
        {
            lock (Lock)
            {
                if (_ctcache != null)
                    return;
                var isController = new Func<Type, bool>(x => x.GetInterfaces().Any(y => y == typeof(IController)));
                var asm = System.Reflection.Assembly.GetExecutingAssembly();
                var defaultControllers = asm.GetTypes().Where(isController);
                //Loaded is a class containing items initialized at Application_Start
                //FromConfig is an IEnumerable<System.Reflection.Assembly>
                var loadedControllers = Loaded.FromConfig.SelectMany(x => x.GetTypes().Where(isController));
                _ctcache = defaultControllers.Union(loadedControllers)
                    .GroupBy(x => x.Name)
                    .ToDictionary(x => x.Key.Replace("Controller", ""), types => types.ToLookup(y => y.Namespace) as Lookup<string, Type>);
            }
        }
        //Lifted from the DefaultControllerFactory since it's an internal method.
        private static bool IsNamespaceMatch(string requestedNamespace, string targetNamespace)
        {
            if (requestedNamespace == null)
            {
                return false;
            }
            if (requestedNamespace.Length == 0)
            {
                return true;
            }
            if (!requestedNamespace.EndsWith(".*", StringComparison.OrdinalIgnoreCase))
            {
                return string.Equals(requestedNamespace, targetNamespace, StringComparison.OrdinalIgnoreCase);
            }
            requestedNamespace = requestedNamespace.Substring(0, requestedNamespace.Length - ".*".Length);
            if (!targetNamespace.StartsWith(requestedNamespace, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return (requestedNamespace.Length == targetNamespace.Length) || (targetNamespace[requestedNamespace.Length] == '.');
        }
    }
