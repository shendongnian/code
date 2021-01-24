    namespace PubManager.Domain.Users
    {
        public static class SecurityExtensions
        {
            public static string Name(this IPrincipal user)
            {
                return user.Identity.Name;
            }
            public static UserModel GetWebUser(this IPrincipal principal)
            {
                if (principal == null)
                    return new UserModel();
                var db = new DataContext();
                var user = (from usr in db.Users
                            where usr.UserName == principal.Identity.Name
                            select new UserModel
                            {
                                Title = usr.Person.Title,
                                UserName = usr.UserName,
                                FirstName = usr.Person.FirstName,
                                Surname = usr.Person.LastName,
                                Email = usr.Person.Email,
                                LockedOut = usr.LockedOut,
                                UserId = usr.UserId,
                                IsSystemUser = usr.IsSystemUser,
                                IsGlobalAdmin = usr.IsGlobalAdmin.Value,
                                PersonId = usr.PersonId,
                                Roles = from r in usr.UserToRoles
                                        select new RoleModel
                                        {
                                            RoleId = r.RoleId,
                                            PageToRoles = from ptr in r.Role.PageToRoles
                                                          select new PageToRoleModel
                                                          {
                                                              RolePage = new RolePageModel
                                                              {
                                                                  Controller = ptr.RolePage.Controller,
                                                                  View = ptr.RolePage.View
                                                              }
                                                          }
                                        }
                            }).FirstOrDefault();
                if (user != null)
                {                     
                        HttpContext.Current.Session["user"] = user;
                }
                return user;
            }
        }
    }
