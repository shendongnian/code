    public static class ServiceCollectionExtensions
    {
        public static void Remove<T>(this IServiceCollection services)
        {
            var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            if (serviceDescriptor != null) services.Remove(serviceDescriptor);
        }
    }
