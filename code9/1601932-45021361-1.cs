    using System.Linq;
    using NHibernate.Linq;
    
    // ...
    
    var projects = s.Query<Project>()
        .Where(p => p.DeletedDate == null)
        .Where(
            p => p.ProjectUsers.Any(pu => pu.UserID == loggedUserID) ||
                p.Roles.Any(pr => userRoles.Contains(pr.RoleID)))
        .ToList();
