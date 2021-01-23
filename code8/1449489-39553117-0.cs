        public class Global : HttpApplication
    	{
    		private void Application_Start(object sender, EventArgs e)
    		{
    			IUnityContainer container = new UnityContainer();
                container.RegisterType<IUserService, UserService>();
                container.RegisterType<IUserLogic, UserLogic>();
    			UnityDependencyResolver dependencyResolver = new UnityDependencyResolver(container);
    			GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
    			DependencyResolver.SetResolver(dependencyResolver);
    		}
    	}
