    public static VersionInformationModel GetVersionInformation() {
      var Result = new VersionInformationModel {
        Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
        BuildDate = System.IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location),
        Configuration = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyConfigurationAttribute>().Configuration,
        TargetFramework = Assembly.GetExecutingAssembly().GetCustomAttribute<System.Runtime.Versioning.TargetFrameworkAttribute>().FrameworkName,
      };
      return Result;
    }
