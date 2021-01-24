    var query = (from u in users
         where u.Roles.Any(r => r.RoleId == role.Id)
         from t in u.ProjectTasks.Where(x => x.Users.Any(user => user.Id == u.Id)).DefaultIfEmpty()
         where ((u.ProjectTasks.Count() == 0) || u.ProjectTasks.Count(z => z.Status == Status.Active || z.Status == Status.Testing) <= 3)
         select new { User = u } into Users
         group Usersby Users.User).ToList(); 
