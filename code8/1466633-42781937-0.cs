    Task("Default")
        .Does(() =>
    {
        Information("Hello World!");
        if (!BuildSystem.IsLocalBuild) 
        {
            GitVersion(new GitVersionSettings {
                UpdateAssemblyInfo = true,
                OutputType = GitVersionOutput.BuildServer
            });
        }
        GitVersion versionInfo = GitVersion(new GitVersionSettings{ OutputType = GitVersionOutput.Json });
        Information("Version: " + versionInfo.NuGetVersion);
        MSBuild("./CEST.sln");
    });
