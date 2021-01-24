    string slnFilePath = "..."; // path to SLN file
    MSBuildWorkspace workspace = MSBuildWorkspace.Create();
    var solution = workspace.OpenSolutionAsync(slnFilePath).Result;
    foreach (var project in solution.Projects)
    {
        Console.WriteLine($"{project.Name} : {project.CompilationOptions.OutputKind}");
    }
