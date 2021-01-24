    var fileVersion = Assembly.GetEntryAssembly()
        .GetCustomAttribute<AssemblyFileVersionAttribute>()
        .Version;
    var informationalVersion = Assembly.GetEntryAssembly()
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
        .InformationalVersion;
