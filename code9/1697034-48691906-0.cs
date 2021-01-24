    var assn = dataContext.ProjectAssignees
                       .Where(r => r.Project.Name == project.Name && r.IsActive)
                       .Include(u => u.User)
                       .Include("User.AssigneeMonths")
                       .ToList();
