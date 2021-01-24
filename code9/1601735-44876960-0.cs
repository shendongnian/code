    EnvDTE.Project project = (EnvDTE.Project)selectedProjects.GetValue(0);
    var vcproj = project.Object as VCProject;
    VCConfiguration cfg = (VCConfiguration)vcproj.ActiveConfiguration;
    VCDebugSettings debug = (VCDebugSettings)cfg.DebugSettings;
    
    //string path = debug.WorkingDirectory;
    string path = cfg.Evaluate(debug.WorkingDirectory);
    
    // Here path is $(ProjectDir) But I need something like c:\myProject
    // Resolution can be done because Visual can do: my question is : How ?
