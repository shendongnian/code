    #tool "nuget:https://www.nuget.org/api/v2/?package=KuduSync.NET"
    
    #addin "nuget:https://www.nuget.org/api/v2/?package=Cake.Kudu"
    
    ///////////////////////////////////////////////////////////////////////////////
    
    // ARGUMENTS
    
    ///////////////////////////////////////////////////////////////////////////////
    
    
    var target = Argument<string>("target", "Default");
    
    var configuration = Argument<string>("configuration", "Release");
    
    ///////////////////////////////////////////////////////////////////////////////
    
    // GLOBAL VARIABLES
    
    ///////////////////////////////////////////////////////////////////////////////
    
    var webRole = (EnvironmentVariable("web_role") ?? string.Empty).ToLower();
    
    var solutionPath = MakeAbsolute(File("./src/MultipleWebSites.sln"));
    
    string outputPath = MakeAbsolute(Directory("./output")).ToString();
    
    string testsOutputPath = MakeAbsolute(Directory("./testsOutputPath")).ToString();
    
    
    DirectoryPath websitePath,
    
                    websitePublishPath,
    
                    testsPath;
    
    
    FilePath projectPath,
    
                testsProjectPath;
    
    switch(webRole)
    
    {
    
        case "api":
    
            {
    
                websitePath = MakeAbsolute(Directory("./src/Api"));
    
                projectPath = MakeAbsolute(File("./src/Api/Api.csproj"));
    
                testsPath = MakeAbsolute(Directory("./src/Api.Tests"));
    
                testsProjectPath = MakeAbsolute(File("./src/Api.Tests/Api.Tests.csproj"));
    
                websitePublishPath = MakeAbsolute(Directory("./output/_PublishedWebsites/Api"));
    
                break;
    
            }
    
        case "frontend":
    
            {
    
                websitePath = MakeAbsolute(Directory("./src/Frontend"));
    
                projectPath = MakeAbsolute(File("./src/Frontend/Frontend.csproj"));
    
                testsPath = MakeAbsolute(Directory("./src/Frontend.Tests"));
    
                testsProjectPath = MakeAbsolute(File("./src/Frontend.Tests/Frontend.Tests.csproj"));
    
                websitePublishPath = MakeAbsolute(Directory("./output/_PublishedWebsites/Frontend"));
    
                break;
    
            }
    
        case "backoffice":
    
            {
    
                websitePath = MakeAbsolute(Directory("./src/Backoffice"));
    
                projectPath = MakeAbsolute(File("./src/Backoffice/Backoffice.csproj"));
    
                testsPath = MakeAbsolute(Directory("./src/Backoffice.Tests"));
    
                testsProjectPath = MakeAbsolute(File("./src/Backoffice.Tests/Backoffice.Tests.csproj"));
    
                websitePublishPath = MakeAbsolute(Directory("./output/_PublishedWebsites/Backoffice"));
    
                break;
    
            }
    
        default:
    
            {
    
                throw new Exception(
    
                string.Format(
    
                        "Unknown web role {0}!",
    
                        webRole
    
                    )
    
                );
    
            }
    
    }
    
    
    if (!Kudu.IsRunningOnKudu)
    
    {
    
        throw new Exception("Not running on Kudu");
    
    }
    
    
    var deploymentPath = Kudu.Deployment.Target;
    
    if (!DirectoryExists(deploymentPath))
    
    {
    
        throw new DirectoryNotFoundException(
    
            string.Format(
    
                "Deployment target directory not found {0}",
    
                deploymentPath
    
                )
    
            );
    
    }
    
    
    ///////////////////////////////////////////////////////////////////////////////
    
    // SETUP / TEARDOWN
    
    ///////////////////////////////////////////////////////////////////////////////
    
    
    Setup(() =>
    
    {
    
        // Executed BEFORE the first task.
    
        Information("Running tasks...");
    
    });
    
    
    Teardown(() =>
    
    {
    
        // Executed AFTER the last task.
    
        Information("Finished running tasks.");
    
    });
    
    
    ///////////////////////////////////////////////////////////////////////////////
    
    // TASK DEFINITIONS
    
    ///////////////////////////////////////////////////////////////////////////////
    
    
    Task("Clean")
    
        .Does(() =>
    
    {
    
        //Clean up any binaries
    
        Information("Cleaning {0}", outputPath);
    
        CleanDirectories(outputPath);
    
    
        Information("Cleaning {0}", testsOutputPath);
    
        CleanDirectories(testsOutputPath);
    
    
        var cleanWebGlobber = websitePath + "/**/" + configuration + "/bin";
    
        Information("Cleaning {0}", cleanWebGlobber);
    
        CleanDirectories(cleanWebGlobber);
    
    
        var cleanTestsGlobber = testsPath + "/**/" + configuration + "/bin";
    
        Information("Cleaning {0}", cleanTestsGlobber);
    
        CleanDirectories(cleanTestsGlobber);
    
    });
    
    
    Task("Restore")
    
        .Does(() =>
    
    {
    
        // Restore all NuGet packages.
    
        Information("Restoring {0}...", solutionPath);
    
        NuGetRestore(solutionPath);
    
    });
    
    
    Task("Build")
    
        .IsDependentOn("Clean")
    
        .IsDependentOn("Restore")
    
        .Does(() =>
    
    {
    
        // Build target web & tests.
    
        Information("Building web {0}", projectPath);
    
        MSBuild(projectPath, settings =>
    
            settings.SetPlatformTarget(PlatformTarget.MSIL)
    
                .WithProperty("TreatWarningsAsErrors","true")
    
                .WithProperty("OutputPath", outputPath)
    
                .WithTarget("Build")
    
                .SetConfiguration(configuration));
    
    
        Information("Building tests {0}", testsProjectPath);
    
        MSBuild(testsProjectPath, settings =>
    
            settings.SetPlatformTarget(PlatformTarget.MSIL)
    
                .WithProperty("TreatWarningsAsErrors","true")
    
                .WithProperty("ReferencePath", outputPath)
    
                .WithProperty("OutputPath", testsOutputPath)
    
                .WithTarget("Build")
    
                .SetConfiguration(configuration));
    
    });
    
    
    Task("Run-Unit-Tests")
    
        .IsDependentOn("Build")
    
        .Does(() =>
    
    {
    
        XUnit2(testsOutputPath + "/**/*.Tests.dll", new XUnit2Settings {
    
            NoAppDomain = true
    
            });
    
    });
    
    
    Task("Publish")
    
        .IsDependentOn("Run-Unit-Tests")
    
        .Does(() =>
    
    {
    
        Information("Deploying web from {0} to {1}", websitePublishPath, deploymentPath);
    
        Kudu.Sync(websitePublishPath);
    
    });
    
    
    
    Task("Default")
    
        .IsDependentOn("Publish");
    
    
    
    ///////////////////////////////////////////////////////////////////////////////
    
    // EXECUTION
    
    ///////////////////////////////////////////////////////////////////////////////
    
    
    RunTarget(target);
