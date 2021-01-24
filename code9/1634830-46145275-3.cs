		public class MvcApplication : HttpApplication
		{
			protected void Application_Start()
			{
				//Default Application_Start() content		
				//...
				
				//Using our DI
				var container = DependencyContainer.CreateContainer(typeof(MvcApplication).Assembly);
				DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			}
		}
