     public static class UserManager
    {
        public static string GetDisplayName(string name)
        {
            using (UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), name))
            {
                if (user != null)
                {
                    return user.DisplayName;
                }
                throw new Exception("error");
            }
        }
    }
