	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.MapRoute(
			name: "MyRoute",
			url: "MyRoute/{action}/{id}",
			defaults: new { controller = MVC.Admin.Hierarchy.Name, action = MVC.Admin.Hierarchy.ActionNames.Index, id = UrlParameter.Optional },
			namespaces: new[] { "Example.WebIU.Areas.Admin.Controllers" }
		).DataTokens["area"] = "Admin";
	
		routes.MapRoute(
			name: "Default",
			url: "{controller}/{action}/{id}",
			defaults: new { area = MVC.Public.Name, controller = MVC.Public.News.Name, action = MVC.Public.News.ActionNames.Index, id = UrlParameter.Optional },
			namespaces: new[] { "Example.WebIU.Areas.Public.Controllers" }
		);
	}
