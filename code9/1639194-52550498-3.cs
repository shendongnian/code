    #tool nuget:?package=xunit.runner.console
    // Configuration argument that can be passed via command line
    // Default is "Release"
    var configuration = Argument("configuration", "Release");
    // ... omitted for brevity
    // Run all test projects located in ./test folder
    Task("Test")
      .IsDependentOn("Build")
      .Does(() =>
      {
        var projects = GetFiles("./test/**/*.Tests.csproj");
        foreach(var project in projects)
        {
          DotNetCoreTest(
            project.FullPath,
            new DotNetCoreTestSettings()
              {
                // Set configuration as passed by command line
                Configuration = configuration
              });
        }
    });
