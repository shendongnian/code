      // using System.Reflection; 
      var version = typeof(<any type from an assembly which version you need>)
            .GetTypeInfo()
            .Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            .InformationalVersion;
