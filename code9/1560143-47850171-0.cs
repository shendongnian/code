    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    
    using Microsoft.Extensions.DependencyInjection;
    using System.Web.Http.Dependencies;
    using ProductsApp.Controllers;
    
    namespace ProductsApp
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API routes
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
    
    
                // create the DI services and make the default resolver
                var services = new ServiceCollection();
                services.AddTransient(typeof(DefaultProduct));
                services.AddTransient(typeof(ProductsController));
    
                var resolver = new MyDependencyResolver(services.BuildServiceProvider());
                config.DependencyResolver = resolver;
            }
        }
    
        public class DefaultProduct : ProductsApp.Models.Product
        {
            public DefaultProduct()
            {
                this.Category = "Computing";
                this.Id = 999;
                this.Name = "Direct Injection";
                this.Price = 99.99M;
            }
        }
    
        /// <summary>
        /// Provides the default dependency resolver for the application - based on IDependencyResolver, which hhas just two methods
        /// </summary>
        public class MyDependencyResolver : IDependencyResolver
        {
            protected IServiceProvider _serviceProvider;
    
            public MyDependencyResolver(IServiceProvider serviceProvider)
            {
                this._serviceProvider = serviceProvider;
            }
    
            public IDependencyScope BeginScope()
            {
                return this;
            }
    
            public void Dispose()
            {
    
            }
    
            public object GetService(Type serviceType)
            {
                return this._serviceProvider.GetService(serviceType);
            }
    
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return this._serviceProvider.GetServices(serviceType);
            }
    
            public void AddService()
            {
    
            }
        }
    
        public static class ServiceProviderExtensions
        {
            public static IServiceCollection AddControllersAsServices(this IServiceCollection services, IEnumerable<Type> serviceTypes)
            {
                foreach (var type in serviceTypes)
                {
                    services.AddTransient(type);
                }
    
                return services;
            }
        }
    }
