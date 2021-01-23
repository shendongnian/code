    var allowPrereleaseVersions = true;
    var allowUnlisted = false;
    INuGetProjectContext projectContext = new ProjectContext();
    ResolutionContext resolutionContext = new ResolutionContext(
        DependencyBehavior.Lowest,
        allowPrereleaseVersions,
        allowUnlisted,
        VersionConstraints.None);
    
    var jsonPackage = jsonNugetPackages.First();
    var identity = new PackageIdentity(jsonPackage.Identity.Id, jsonPackage.Identity.Version);
    await packageManager.InstallPackageAsync(
        project,
        identity,
        resolutionContext,
        projectContext,
        sourceRepository,
        new List<SourceRepository>(),
        CancellationToken.None);
