    using System.DirectoryServices.AccountManagement;
    using System.Web.Hosting;
    
        using (HostingEnvironment.Impersonate())
        {
                     PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                     user = UserPrincipal.FindByIdentity(ctx, txtUser.Text.Trim());
        }
