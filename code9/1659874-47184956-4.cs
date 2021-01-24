	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// add this to ensure that casing is converted between camel case (front end) and pascal case (c#/backend)
			var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			
			config.MapHttpAttributeRoutes();
		}
	}
