    public class CustomRoleProvider : RoleProvider
    {
        private mydatabase db;
        public override string ApplicationName { get; set; }
        public CustomRoleProvider()
        {
            db = new mydatabase();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
			//This will return the user object.
			//To get the username of the logged on user, you can use User.Identity.Name
			//To remove the domain name from the username: User.Identity.Name.Split('\\').Last();
            var user = db.CurrentUser();
            return user.Roles != null
                && user.Roles.Count > 0
                && (user.Roles.Exists(x => x.Roles.RoleNm == roleName));
        }
        public override string[] GetRolesForUser(string username)
        {
            var user = db.CurrentUser();
			return user.Roles.Select(x => x.Roles.RoleNm).ToArray();
        }
        #region not implemented
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
