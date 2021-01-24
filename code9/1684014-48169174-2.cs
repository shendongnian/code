    var result = myDbContext.Steps
       .Where(step => ...)
       .Select(step => new
        {
            Name = step.Name,
            ... // other properties
            ApplicationUsers = step.ApplicationUsers
                .Where(applicationUser => ...)
                .Select(applicationUser => new
                {
                   ...
                })
                .ToList(),
        });
