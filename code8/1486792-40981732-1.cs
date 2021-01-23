    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Mvc;
    using Common.Logging;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Mvc;
    
    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DiTestingApp.App_Start.UnityWebActivator), "Start")]
    [assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(DiTestingApp.App_Start.UnityWebActivator), "Shutdown")]
    
    namespace DiTestingApp.App_Start
    {
        /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
        public static class UnityWebActivator
        {
            private static readonly ILog Log = LogManager.GetLogger(typeof(UnityWebActivator));
            /// <summary>
            /// Get the hangfire container.
            /// </summary>
            private static readonly Lazy<IUnityContainer> WebContainer = new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                container.Configure(() => new PerRequestLifetimeManager());
                return container;
            });
    
            /// <summary>Integrates Unity when the application starts.</summary>
            public static void Start() 
            {
                Log.Info("Web api DI container intializing.");
                var container = WebContainer.Value;
    
                FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
                FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));
    
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    
                // TODO: Uncomment if you want to use PerRequestLifetimeManager
                Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
    
                var resolver = new Microsoft.Practices.Unity.WebApi.UnityDependencyResolver(container);
    
                GlobalConfiguration.Configuration.DependencyResolver = resolver;
                Log.Info("Web api DI container intialization complete.");
            }
    
            /// <summary>Disposes the Unity container when the application is shut down.</summary>
            public static void Shutdown()
            {
                Log.Info("Web api DI container disposing.");
                var container = WebContainer.Value;
                container.Dispose();
            }
        }
    }
