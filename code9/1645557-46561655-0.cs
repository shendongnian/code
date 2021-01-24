    private static void SetupTasks(bool isDotNetCoreBuild)
    {
        var prefix = isDotNetCoreBuild ? "DotNetCore-" : "";
        BuildParameters.Tasks.CreateNuGetPackagesTask.IsDependentOn(prefix + "Build");
        BuildParameters.Tasks.CreateChocolateyPackagesTask.IsDependentOn(prefix + "Build");
        BuildParameters.Tasks.TestTask.IsDependentOn(prefix + "Build");
        BuildParameters.Tasks.DupFinderTask.IsDependentOn(prefix + "Build");
        BuildParameters.Tasks.InspectCodeTask.IsDependentOn(prefix + "Build");
        BuildParameters.Tasks.PackageTask.IsDependentOn("Analyze");
        BuildParameters.Tasks.PackageTask.IsDependentOn("Test");
        BuildParameters.Tasks.PackageTask.IsDependentOn("Create-NuGet-Packages");
        BuildParameters.Tasks.PackageTask.IsDependentOn("Create-Chocolatey-Packages");
        BuildParameters.Tasks.UploadCodecovReportTask.IsDependentOn("Test");
        BuildParameters.Tasks.UploadCoverallsReportTask.IsDependentOn("Test");
        BuildParameters.Tasks.AppVeyorTask.IsDependentOn("Upload-Coverage-Report");
        BuildParameters.Tasks.AppVeyorTask.IsDependentOn("Publish-Chocolatey-Packages");
        BuildParameters.Tasks.InstallReportGeneratorTask.IsDependentOn(prefix + "Build");
        if (!isDotNetCoreBuild)
        {
            BuildParameters.Tasks.TestTask.IsDependentOn("Test-NUnit");
            BuildParameters.Tasks.TestTask.IsDependentOn("Test-xUnit");
            BuildParameters.Tasks.TestTask.IsDependentOn("Test-MSTest");
            BuildParameters.Tasks.TestTask.IsDependentOn("Test-VSTest");
            BuildParameters.Tasks.TestTask.IsDependentOn("Test-Fixie");
            BuildParameters.Tasks.InstallOpenCoverTask.IsDependentOn("Install-ReportUnit");
        }
        else
        {
            BuildParameters.Tasks.TestTask.IsDependentOn(prefix + "Test");
            BuildParameters.Tasks.InstallOpenCoverTask.IsDependentOn("Install-ReportGenerator");
            BuildParameters.Tasks.PackageTask.IsDependentOn(prefix + "Pack");
        }
    }
