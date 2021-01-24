    var projectList = dte.Solution.Projects
        .Cast<EnvDTE.Project>()
        .Where(p => p.Kind == EnvDTE80.ProjectKinds.vsProjectKindSolutionFolder)
        .Where(folder => folder.ProjectItems != null)
        .SelectMany(folder => folder.ProjectItems)
        .Where(item => item.Object is EnvDTE.Project)
        .Select(item => item.Object as EnvDTE.Project)
    
    var projects = dte.Solution.Projects.Cast<EnvDTE.Project>()
        .Where(p => p.Kind != EnvDTE80.ProjectKinds.vsProjectKindSolutionFolder);
    projectList.Concat(projects)
        .Where(p=>p.Name == projectName)
        .First(); // <-- exception ORIGINATES HERE
