public static ILifetimeScope GetLifetimeScope(this HttpContext httpContext)
{
   return httpContext.RequestServices.GetService(typeof(ILifetimeScope)) as ILifetimeScope;
}
Now you can easily get to the "per request" lifetime scope with the following code, given an instance of `IComponentContext`.
ctx => {
  var requestScope = ctx.Resolve<IHttpContextAccessor>().HttpContext.GetLifetimeScope();
  var shortLived = requestScope.Resolve<ShortLived>();
}
---
---
In traditional **ASP.NET**, there is a "dependency resolver" instead of a "service provider".
e.g. `GlobalConfiguration.Configuration.DependencyResolver` = *integrate autofac here*
Resolving the `ILifetimeScope` is a little messier.
public static ILifetimeScope GetLifetimeScope(this HttpContext httpContext)
{
    var requestMessage = httpContext.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
    return requestMessage?.GetDependencyScope().GetService(typeof(ILifetimeScope)) as ILifetimeScope;
}
var requestScope = HttpContext.Current.GetLifetimeScope();
var shortLived = requestScope.Resolve<ShortLived>();
