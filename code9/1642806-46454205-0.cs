     public class MessagBasedControllerActionSelectorAttribute : ActionMethodSelectorAttribute
        {
            private const string RequestHashCodeKey = "RequestHashCodeKey";
            private const string MessageRootNameKey = "MessageRootNameKey";
            private readonly string _messageTypeName;
            private ICacheService _cache;
    
            public MessagBasedControllerActionSelectorAttribute(string messageTypeName)
            {
                _messageTypeName = messageTypeName;
            }
    
            public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
            {
                //Get reference to cache from DI container
                _cache = routeContext.HttpContext.RequestServices.GetService(typeof(ICacheService)) as ICacheService;
    
                //Get Request hashCode from cache if is possible
                var existingRequestHash = _cache.Get<string>(RequestHashCodeKey);
                var req = routeContext.HttpContext.Request;
                var messageName = string.Empty;
                int.TryParse(existingRequestHash, out int cacheRequestHash);
    
                //Verify if the incoming request is the same that has been cached before or deserialize the body in case new request
                if (cacheRequestHash != req.GetHashCode())
                {
                    //store new request hash code
                    _cache.Store(RequestHashCodeKey, req.GetHashCode().ToString());
                    //enable to rewind the body stream this allows then put position 0 and let the model binder serialize again
                    req.EnableRewind();
                    var xmlBody = "";
                    req.Body.Position = 0;
    
                    //Read XML
                    using (StreamReader reader
                        = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
                    {
                        xmlBody = reader.ReadToEnd();
                    }
    
    
                    XmlDocument xmlDoc = new XmlDocument();
                    var xml = XDocument.Parse(xmlBody);
                    //Get the root name
                    messageName = xml.Root.Name.LocalName;
                    //Store the root name in cache
                    _cache.Store(MessageRootNameKey, messageName);
    
                    req.Body.Position = 0;
                }
                else
                {
                    //Get root name from cache
                    messageName = _cache.Get<string>(MessageRootNameKey);
                }
    
                return messageName == _messageTypeName;
            }
        }
