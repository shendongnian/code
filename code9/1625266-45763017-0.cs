	protected void Application_Start(object sender, EventArgs e)
	{
		Bootstrapper.Initialized += Bootstrapper_Initialized;
	}
	void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
	{
		if (e.CommandName == "Bootstrapped")
		{
			System.Web.Mvc.RouteCollectionExtensions.MapRoute(System.Web.Routing.RouteTable.Routes,
			 "Classic",
			 "customprefix/{controller}/{action}/{id}",
			 new { controller = "Feature", action = "Index", id = (string)null }
			);
		}
	}
