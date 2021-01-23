      List<Project> projects = intProjects
        .EmptyIfNull()
        .Concat(extProjects.EmptyIfNull())
        .Concat(mgmProjects.EmptyIfNull())
        .ToList();
