    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    /// <summary>
    /// Resolves dependencies against the current DI container.
    /// </summary>
    public class UnityDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// The container
        /// </summary>
        private readonly IUnityContainer container;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public UnityDependencyResolver(IUnityContainer container) 
        {
            this.container = container;
        }
        /// <summary>
        /// Resolves an instance of the default requested type from the container.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the object to get from the container.</param>
        /// <returns>The requested object, if it can be resolved; otherwise, <c>null</c>.</returns>
        public object GetService(Type serviceType)
        {
            return this.container.IsRegistered(serviceType) 
                ? this.container.Resolve(serviceType) 
                : null;
        }
        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>The requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType);
        }
    }
