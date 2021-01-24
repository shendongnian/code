    Task("Test")
       .Does(() =>
    {
        DotNetCoreTest(
            "path/to/Project.Tests",
            new DotNetCoreTestSettings
            {
                ArgumentCustomization = args => args.Append("--teamcity")
            });
    });
