    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection @this, IConfiguration configuration)
        {
            var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();
            var allTypes = assembliesToScan.Where(a => a.GetName().Name != "AutoMapper").SelectMany(a => a.DefinedTypes).ToArray();
            var profiles = allTypes.Where(t =>
            {
                if (typeof(Profile).GetTypeInfo().IsAssignableFrom(t))
                    return !t.IsAbstract;
                return false;
            }).ToArray();
            Mapper.Initialize(expression =>
            {
                foreach (var type in profiles.Select(t => t.AsType()))
                    expression.AddProfile((Profile)Activator.CreateInstance(type, configuration));
            });
            return @this;
        }
    }
