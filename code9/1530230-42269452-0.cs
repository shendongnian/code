    public static class ControllerExtensions
    {
    	public static ControllerContext GetFakeControllerContext()
    	{
    		HttpContext.Current = HttpContext.Current ?? GetFakeHttpContext();
    
    		var currentContext = HttpContext.Current;
    
    		var controller = CreateController<FakeController>();
    
    		var st = new StringWriter();
    		var context = new HttpContextWrapper(currentContext);
    		var routeData = GetFakeRouteData(controller);
    
    		var controllerContext = new ControllerContext(new RequestContext(context, routeData), controller);
    
    		return controllerContext;
    	}
    
    	public static HttpContext GetFakeHttpContext()
    	{
    		var httpRequest = new HttpRequest("", "http://stackoverflow/", "");
    		var stringWriter = new StringWriter();
    		var httpResponse = new HttpResponse(stringWriter);
    		var httpContext = new HttpContext(httpRequest, httpResponse);
    
    		var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
    												new HttpStaticObjectsCollection(), 10, true,
    												HttpCookieMode.AutoDetect,
    												SessionStateMode.InProc, false);
    
    		httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
    									BindingFlags.NonPublic | BindingFlags.Instance,
    									null, CallingConventions.Standard,
    									new[] { typeof(HttpSessionStateContainer) },
    									null)
    							.Invoke(new object[] { sessionContainer });
    
    		return httpContext;
    	}
    
    	public static RouteData GetFakeRouteData(Controller controller)
    	{
    		var routeData = new RouteData();
    
    		if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
    			routeData.Values.Add("controller", controller.GetType().Name
    														.ToLower()
    														.Replace("controller", ""));
    
    		return routeData;
    	}
    
    	public static T CreateController<T>(RouteData routeData = null)
    		where T : Controller, new()
    	{
    		T controller = new T();
    
    		// Create an MVC Controller Context
    		var wrapper = new HttpContextWrapper(System.Web.HttpContext.Current);
    
    		if (routeData == null)
    			routeData = new RouteData();
    
    		if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
    			routeData.Values.Add("controller", controller.GetType().Name
    														.ToLower()
    														.Replace("controller", ""));
    
    		controller.ControllerContext = new ControllerContext(wrapper, routeData, controller);
    		return controller;
    	}
    }
    
    public class FakeController : Controller
    {
    
    }
