    public static class ServiceProviderExtensions {
        /// <summary>
        /// Inject dependencies into an existing instance based on interface properties with setters.
        /// </summary>
        /// <param name = "instance">The instance.</param>
        public static void BuildUp(this IServiceProvider provider, object instance) {
            var injectables = instance.GetType().GetProperties()
                              .Where(property => property.CanWrite && property.PropertyType.IsInterface());
            foreach (var propertyInfo in injectables) {
                var injection = provider.GetServices(propertyInfo.PropertyType).ToArray();
                if (injection.Any()) {
                    propertyInfo.SetValue(instance, injection.First(), null);
                }
            }
        }
        /// <summary>
        /// Get service of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        public static TService GetService<TService>(this IServiceProvider provider) {
            return (TService)provider.GetService(typeof(TService));
        }
        /// <summary>
        /// Get an enumeration of services of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>
        /// </summary>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType) {
            var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetService(genericEnumerable);
        }
        /// <summary>
        /// Get an enumeration of services of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        public static IEnumerable<TService> GetServices<TService>(this IServiceProvider provider) {
            return provider.GetServices(typeof(TService)).Cast<TService>();
        }
    }
