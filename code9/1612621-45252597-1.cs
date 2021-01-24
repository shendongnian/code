      var version = typeof(Microsoft.Extensions.Logging.LoggerFactory)
            .GetTypeInfo()
            .Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            .InformationalVersion;
