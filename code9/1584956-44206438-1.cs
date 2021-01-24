    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using global::Ninject;
    using global::Ninject.Infrastructure.Disposal;
    using global::Ninject.Parameters;
    using global::Ninject.Syntax;
    public class DependencyScopeWebApiNinject : DisposableObject, IDependencyScope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyScopeWebApiNinject"/> class.
        /// </summary>
        /// <param name="resolutionRoot">The resolution root.</param>
        public DependencyScopeWebApiNinject(IResolutionRoot resolutionRoot)
        {
            this.ResolutionRoot = resolutionRoot;
        }
        /// <summary>
        /// Gets the resolution root.
        /// </summary>
        /// <value>The resolution root.</value>
        protected IResolutionRoot ResolutionRoot
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the service of the specified type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns>The service instance or <see langword="null"/> if none is configured.</returns>
        public object GetService(Type serviceType)
        {
            var request = this.ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.ResolutionRoot.Resolve(request).SingleOrDefault();
        }
        /// <summary>
        /// Gets the services of the specifies type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns>All service instances or an empty enumerable if none is configured.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.ResolutionRoot.GetAll(serviceType).ToList();
        }
    }
