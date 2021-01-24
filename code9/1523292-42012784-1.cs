    public class IsUserInRole
    {
        public bool IsInGroup(string groupName)
        {
            var myIdentity = GetUserIdWithDomain();
            var myPrincipal = new WindowsPrincipal(myIdentity);
            return myPrincipal.IsInRole(groupName);
        }
        public  WindowsIdentity GetUserIdWithDomain()
        {
            var myIdentity = WindowsIdentity.GetCurrent();
            return myIdentity;
        }
        public string GetUserId()
        {
            return GetUserInformation().Name;
        }
        public string GetUserDisplayName()
        {
            return GetUserInformation().DisplayName;
        }
        public UserPrincipal GetUserInformation()
        {
            var id = GetUserIdWithDomain().Name.Split('\\');
            var dc = new PrincipalContext(ContextType.Domain, id[0]);
            return UserPrincipal.FindByIdentity(dc, id[1]);
        }
        public UserPrincipal GetUserInformation(string domain, string lanId)
        {
            var dc = new PrincipalContext(ContextType.Domain, domain);
            return UserPrincipal.FindByIdentity(dc, lanId);
        }
    }
