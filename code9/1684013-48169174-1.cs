    var result = myDbContext.ApplicationUsers
        .Where(applicationUser => applicationUser.Name == ...)
        .Select(applicationUser => new
        {
             // select only the properties you plan to use:
             Name = applicationUser.Name,
             Steps = applicationUser.Steps
                 .Where(step => step.Name == ...)
                 .Select(step => new
                 {
                     // again fetch only Step properties you  plan to use
                     Name = step.Name,
                     ...
                 })
                 .ToList(),
         });
