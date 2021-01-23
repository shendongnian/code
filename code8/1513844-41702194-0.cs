    public class RoleManager
    {
        private User currentUser;
        public string GetReadRole(Item item)
        {
            currentUser = Sitecore.Context.User;
            //int found = 0;
            foreach (Role role in currentUser.Roles)
            {
                return role.LocalName; //return the role they are in
            }
            return "";
        }
    }
