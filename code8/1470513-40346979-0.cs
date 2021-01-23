    var result = from u in le.AspNetUsers
                 select new
                 {
                     Id = u.Id,
                     UserName = u.UserName,
                     Correo = u.Email,
                     Roles = u.AspNetRoles.Select(r => r.Name)
                 };
