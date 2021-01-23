    using System;
    using System.Web.Http;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Unity.WebApi;
    
    namespace Blah.Endpoints.App_Start
    {
        /// <summary>
        /// Specifies the Unity configuration for the main container.
        /// </summary>
        public static class UnityConfig
        {
            public static void RegisterComponents()
            {
                var container = new UnityContainer();
    
                // register all your components with the container here
                // it is NOT necessary to register your controllers
                RegisterTypes(container);
                // e.g. container.RegisterType<ITestService, TestService>();
    
                GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            }
    
            #region Unity Container
            private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });
    
            /// <summary>
            /// Gets the configured Unity container.
            /// </summary>
            public static IUnityContainer GetConfiguredContainer()
            {
                return container.Value;
            }
            #endregion
    
            /// <summary>Registers the type mappings with the Unity container.</summary>
            /// <param name="container">The unity container to configure.</param>
            /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
            /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
            public static void RegisterTypes(IUnityContainer container)
            {
                
                container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                    WithMappings.FromMatchingInterface,
                    WithName.Default,
                    null,                //WithLifetime IF we want to change the lifetime aspect aka Singletons 
                    null,//GetMembers,
                    false
                    );
            }
    
            
        }
    }
