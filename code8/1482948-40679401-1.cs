    var projects = (from project in Context.ProjectSet
                   where project.ModifiedOn > DateTime.Now.AddHours(-1)
                   select new Project(new { 
                   {
                       project.Id,
                       project.ModifiedOn,
                       project.CompanylinkId 
                   }).ToList();
