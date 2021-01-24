    public static class AutoFacExtensions
    {
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterSignalRHubs(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            // typeof(Hub), not typeof(IHub)
            return builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Hub).IsAssignableFrom(t))
                .ExternallyOwned();
        }
    }
