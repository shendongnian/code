    namespace PubManager.Domain.Users
    {
        public class UserModel
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Title { get; set; }
            [Required]
            [DisplayName("Forename")]
            public string FirstName { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            [DisplayName("Company name")]
            public DateTime? LastLogin { get; set; }
            public bool LockedOut { get; set; }
            public DateTime? LockedOutUntil { get; set; }
            public bool IsGlobalAdmin { get; set; }
            public bool? IsSystemUser { get; set; }
            public IEnumerable<RoleModel> Roles { get; set; }
            public bool HasAccess(string controller, string view)
            {
                if (IsGlobalAdmin || IsSystemUser.Value)
                {
                    return true;
                }
                var isAuthorized = false;
                if (!Roles.Any())
                    return false;
                foreach (var role in Roles)
                {
                    if (role.PageToRoles == null)
                        return false;
                    foreach (var pg in role.PageToRoles)
                    {
                        if (pg.RolePage.Controller.Equals(controller, StringComparison.InvariantCultureIgnoreCase) && (pg.RolePage.View.Equals(view, StringComparison.InvariantCultureIgnoreCase) || pg.RolePage.View.Equals("*")))
                            isAuthorized = true;
                    }
                }
                return isAuthorized;
            }
        }
    }
