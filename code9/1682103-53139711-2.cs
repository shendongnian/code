    public class PatchForAttribute : ActionMethodSelectorAttribute
    {
        public Type Type { get; }
    
        public PatchForAttribute(Type type)
        {
            Type = type;
        }
    
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            routeContext.HttpContext.Request.EnableRewind();
            var body = new StreamReader(routeContext.HttpContext.Request.Body).ReadToEnd();
            try
            {
                JsonConvert.DeserializeObject(body, Type, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Error });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                routeContext.HttpContext.Request.Body.Position = 0;
            }
        }
    }
