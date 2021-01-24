        BuildResult result = null;
        using (var pc = new ProjectCollection())
            result = BuildManager.DefaultBuildManager.Build(
                new BuildParameters(pc) { Loggers = new[] { new ConsoleLogger() } },
                // Change this path to your .sln file instead of the .csproj.
                // (It won't work with the .csproj.)
                new BuildRequestData(@"c:\projects\Sample.sln",
                    // Change the parameters as you need them,
                    // e.g. if you want to just Build the Debug (not Rebuild the Release).
                    new Dictionary<string, string>
                    {
                        { "Configuration", "Release" },
                        { "Platform", "Any CPU" }
                    }, null, new[] { "Rebuild" }, null));
        if (result.OverallResult == BuildResultCode.Failure)
            // Something bad happened...
