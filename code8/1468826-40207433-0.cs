    using System.Collections.Generic;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    using System.Security.Principal;
    namespace Santander.IsUserInGroupOrRole_cs
    {
    public class IsUserInRole
    {
        public static bool IsInGroup(string groupName)
        {
            var myIdentity = GetUserIdWithDomain();
            var myPrincipal = new WindowsPrincipal(myIdentity);
            return myPrincipal.IsInRole(groupName);
        }
        public bool IsInGroup(List<string> groupNames)
        {
            var myIdentity = GetUserIdWithDomain();
            var myPrincipal = new WindowsPrincipal(myIdentity);
            return groupNames.Any(group => myPrincipal.IsInRole(group));
        }
        public static WindowsIdentity GetUserIdWithDomain()
        {
            var myIdentity = WindowsIdentity.GetCurrent();
            return myIdentity;
        }
        public static string GetUserId()
        {
            var id = GetUserIdWithDomain().Name.Split('\\');
            return id[1];
        }
        public static string GetUserDisplayName()
        {
            var id = GetUserIdWithDomain().Name.Split('\\');
            var dc = new PrincipalContext(ContextType.Domain, id[0]);
            var adUser = UserPrincipal.FindByIdentity(dc, id[1]);
            return adUser.DisplayName;
        }
    }
    }
