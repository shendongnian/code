    container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
    
    container.Options.LifestyleSelectionBehavior = new WebApiInjectionLifestyle();
    /// <summary>
    /// The web api lifestyle.
    /// </summary>
    internal class WebApiInjectionLifestyle : ILifestyleSelectionBehavior
    {
        /// <summary>
        /// The select lifestyle.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>s
        /// <param name="implementationType">
        /// The implementation type.
        /// </param>
        /// <returns>
        /// The <see cref="Lifestyle"/>.
        /// </returns>
        public Lifestyle SelectLifestyle(Type serviceType, Type implementationType)
        {
            //return Lifestyle.Scoped;
            return WebApiRequestLifestyle.Scoped;
        }
    }
