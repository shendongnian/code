    public class CustomRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            // Do whatever logging you want with this data, maybe grab the other params too.
            return base.GetHttpHandler(context);
        }
    }
