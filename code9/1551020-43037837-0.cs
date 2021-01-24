    Device.BeginInvokeOnMainThread(() =>
     {
         foreach (ProjectDto project in orderedProjects)
         {
             var coll = viewModel.Projects.FirstOrDefault(c => c.Key == project.StartDate);
    
             if (coll == null)
                 viewModel.Projects.Add(coll = new ObservableCollectionWithDateKey { Key = project.StartDate });
    
             coll.Add(project);
         }
     var group = viewModel.Projects.Last();
     if (group != null)
         ProjectsListView.ScrollTo(group.First(), group, ScrollToPosition.Start, false);
    });
