    Task("Restore")
        .Does(() =>
    {
        // Restore all NuGet packages.
        foreach(var solution in solutions)
        {
            Information("Restoring {0}...", solution);
            NuGetRestore(solution);
        }
    });
