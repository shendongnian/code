private string TryGetRouteName(HttpActionExecutedContext ctx)
{
  var route = ctx.ActionContext.RequestContext.RouteData.Route;
  if (route.DataTokens.TryGetValue("actions", out object value) && value != null)
  {
    var actions = (HttpActionDescriptor[])value;
    var executedAction = actions.FirstOrDefault();
    var routeAttributes = executedAction?.GetCustomAttributes<RouteAttribute>(true) ?? new Collection<RouteAttribute>();
    return routeAttributes.FirstOrDefault()?.Name ?? string.Empty;
  }
  
  return string.Empty;
}
