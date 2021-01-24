    List<Project> allProjects = yourQuery.ToList(); // Assuming "Project" is your type
    List<Project> filteredProjects = new List<Project>(); 
    
    if (inProgressCheckBox.IsChecked)
        filteredProjects.AddRange(allProjects.Where(p => p.InProgress));
    if (pendingCheckBox.IsChecked)
        filteredProjects.AddRange(allProjects.Where(p => p.Pending));
    if (completeCheckBox.IsChecked)
        filteredProjects.AddRange(allProjects.Where(p => p.Complete));
    if (postponedCheckBox.IsChecked)
        filteredProjects.AddRange(allProjects.Where(p => p.Postponed));
    if (cancelledCheckBox.IsChecked)
        filteredProjects.AddRange(allProjects.Where(p => p.Cancelled));
    filteredProjects = filteredProjects.Distinct();
