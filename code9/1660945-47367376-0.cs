        public static class RouteExtensions
            {
                public static IRouteBuilder MapSeoFriendlyRoute(this IRouteBuilder routeBuilder, string name,
                    string template, object defaults)
                {
                    var inlineConstraintResolver = (IInlineConstraintResolver)routeBuilder
                        .ServiceProvider
                        .GetService(typeof(IInlineConstraintResolver));
        
                    var defaultsDictionary = new RouteValueDictionary(defaults);
                    routeBuilder.Routes.Add(new SeoFriendlyRoute(routeBuilder.DefaultHandler,
                    name,
                    template,
                    defaultsDictionary,
                    constraints: null,
                    dataTokens: null,
                    inlineConstraintResolver: inlineConstraintResolver));
                    return routeBuilder;
                }
            }
        
        
            public class SeoFriendlyRoute : Route
            {
                public SeoFriendlyRoute(IRouter target, string routeTemplate, IInlineConstraintResolver inlineConstraintResolver) : base(target, routeTemplate, inlineConstraintResolver)
                {
                }
        
                public SeoFriendlyRoute(IRouter target, string routeTemplate, RouteValueDictionary defaults, IDictionary<string, object> constraints, RouteValueDictionary dataTokens, IInlineConstraintResolver inlineConstraintResolver) : base(target, routeTemplate, defaults, constraints, dataTokens, inlineConstraintResolver)
                {
                }
        
                public SeoFriendlyRoute(IRouter target, string routeName, string routeTemplate, RouteValueDictionary defaults, IDictionary<string, object> constraints, RouteValueDictionary dataTokens, IInlineConstraintResolver inlineConstraintResolver) : base(target, routeName, routeTemplate, defaults, constraints, dataTokens, inlineConstraintResolver)
                {
                }
        
                protected override Task OnRouteMatched(RouteContext context)
                {
                    var routeData = context.RouteData;
                    if (routeData != null)
                    {
                        if (routeData.Values.ContainsKey("id"))
                            routeData.Values["id"] = GetIdValue(routeData.Values["id"]);
                    }
                    return base.OnRouteMatched(context);
                }
        
                public override Task RouteAsync(RouteContext context)
                {
                    return base.RouteAsync(context);
                }
        
                private object GetIdValue(object id)
                {
                    if (id == null) return null;
                    var idValue = id.ToString();
                    var regex = new Regex(@"^[\w|\W]+-(?<id>\d+).*$");
                    var match = regex.Match(idValue);
                    return match.Success ? match.Groups["id"].Value : id;
                }
            }
    
    routes.MapSeoFriendlyRoute("AdDetails", "ads/{id}/details",
                    defaults: new { controller = "ads", action = "details" });
