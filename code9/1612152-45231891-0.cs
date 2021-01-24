    using System.Reflection;
    ...
    // One level down the directory where exe file lies
    string path = 
      Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "..");
