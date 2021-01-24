    public class ADServices {
            PrincipalContext prinContext = new PrincipalContext(ContextType.Domain, "ad");
    
            public UserPrincipal GetUser(string userName) {
                UserPrincipal userPrin = UserPrincipal.FindByIdentity(prinContext, userName);
                if (userPrin == null) {
                    throw new Exception("The username " + userName + " does not exist.");
                }
            return userPrin;
        }
    }
