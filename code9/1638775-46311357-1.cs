    using Web;
    using WebActivator;
    [assembly: PostApplicationStartMethod(typeof(SimpleInjectorWebInitializer), nameof(SimpleInjectorWebInitializer.Initialize))]
    namespace Web
    {
	using System.Reflection;
	using System.Web.Http;
	using System.Web.Mvc;
	using Infrastructure;
	using SimpleInjector;
	using SimpleInjector.Integration.Web;
	using SimpleInjector.Integration.Web.Mvc;
	using SimpleInjector.Integration.WebApi;
	public static class SimpleInjectorWebInitializer
	{
		/// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
		public static void Initialize()
		{
			var vContainer = new Container();
			// To use the "greediest constructor" paradigm, add the following line:
			vContainer.Options.ConstructorResolutionBehavior =
				new MostResolvableParametersConstructorResolutionBehavior(vContainer);
			vContainer.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
			InitializeContainer(vContainer);
			// From the docs, these next two lines need to be added for MVC
			vContainer.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			vContainer.RegisterMvcIntegratedFilterProvider();
			// This is for Web Api
			vContainer.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			vContainer.Verify();
			// This is needed for MVC
			DependencyResolver.SetResolver
				(new SimpleInjectorDependencyResolver(vContainer));
			// This is needed for WebApi
			GlobalConfiguration.Configuration.DependencyResolver =
				new SimpleInjectorWebApiDependencyResolver(vContainer);
		}
		private static void InitializeContainer(Container aContainer)
		{
			// This is just a call to a regular static method of a static class
			// that performs the container.Register calls.
			InitializeContainerBindings.InitializeBindings(aContainer);
		}
	}
