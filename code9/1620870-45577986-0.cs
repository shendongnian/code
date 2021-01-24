    using System.DirectoryServices.AccountManagement;
    public bool Login(string user, string password) {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "YOUR DOMAIN WITH ACTIVE DIRECTORY"))
            {
                return pc.ValidateCredentials(user, password);
            }
        }
