	public class PublicAreaRegistration : AreaRegistration 
	{
		public override string AreaName 
		{
			get 
			{
				return "Public";
			}
		}
		public override void RegisterArea(AreaRegistrationContext context) 
		{
			context.MapRoute(
				"Public_default",
				"Public/{action}/{id}",
				new { controller = MVC.Public.News.Name, action = MVC.Public.News.ActionNames.Index, id = UrlParameter.Optional }
			);
		}
	}
