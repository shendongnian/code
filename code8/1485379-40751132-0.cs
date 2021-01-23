    List<Project> empty = new List<Project>();
    List<Project> intProjects = ProjectRepo.GetAllInternalProjects() ?? empty;
    List<Project> extProjects = ProjectRepo.GetAllExternalProjects() ?? empty;
    List<Project> mgmProjects = ProjectRepo.GetAllManagementProjects() ?? empty;
    List<Project> projects = intProjects.Concat(extProjects).Concat(mgmProjects).ToList();
