    var properties = new Dictionary<string, string>
    {
       { "Configuration", "Debug" } // Or "Release", or whatever is known to your projects.
       // ... more properties that could influence your property,
       // e.g. "Platform" ("x86", "AnyCPU", etc.)
    };
    MSBuildWorkspace workspace = MSBuildWorkspace.Create(properties);
    workspace.LoadMetadataForReferencedProjects = true;
    Solution solution = workspace.OpenSolutionAsync("someSolution.sln").Result;
    foreach (Project project in solution.Projects)
                Console.Out.WriteLine(project.OutputFilePath);
    workspace.CloseSolution();
