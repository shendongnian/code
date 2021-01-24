	public class BookingEngine
	{
		public static string Route = "Booking";
		public static void Setup(RouteCollection routes, string route)
		{
			Route = route;
			HostingEnvironment.RegisterVirtualPathProvider(
				new EmbeddedVirtualPathProvider());
			routes.Add(
				name: "CustomPage",
				item: new CustomRouteController());
		}
	}
	
