    using System.Linq;
    
    // ...
    
    var projects = projectsForUserRoles.Union(projectsForUser).ToList();
