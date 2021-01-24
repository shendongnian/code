	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration httpConfig = new HttpConfiguration();
			WebApiConfig.Register(httpConfig);
			
			app.UseJwtBearerAuthentication(AuthConfig.GetOptions());
			app.UseWebApi(httpConfig);
		}
	}
