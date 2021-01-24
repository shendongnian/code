    //using Microsoft.AspNetCore.Mvc.Infrastructure;
    //using Microsoft.AspNetCore.Routing;
    
    //HttpContext httpContext;
    //IActionDescriptorCollectionProvider provider
    //IActionSelector selector
    
    var routeContext = new RouteContext(httpContext);
    var x = selector.SelectBestCandidate(routeContext, provider.ActionDescriptors.Items);
    var route =  new 
    {
        Action = x.RouteValues["Action"],
        Controller = x.RouteValues["Controller"],
        Name = x.AttributeRouteInfo.Name,
        Template = x.AttributeRouteInfo.Template,
        Constrains = x.ActionConstraints,
    };
