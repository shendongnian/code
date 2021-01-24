    public class MachinePermissions
    {
        string machineName { get; set; }
        public List<LocalGroup> localGroups { get; set; }
        public List<string> GetGroupMembers(string sGroupName)
        {
            List<String> myItems = new List<String>();
            GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
            PrincipalSearchResult<Principal> oPrincipalSearchResult = oGroupPrincipal.GetMembers();
            foreach (Principal oResult in oPrincipalSearchResult)
            {
                myItems.Add(oResult.Name);
            }
            return myItems;
        }
        private GroupPrincipal GetGroup(string sGroupName)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();
            GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName);
            return oGroupPrincipal;
        }
        private PrincipalContext GetPrincipalContext()
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Machine);
            return oPrincipalContext;
        }
        public MachinePermissions()
        {
            machineName = Environment.MachineName;
            PrincipalContext ctx = new PrincipalContext(ContextType.Machine, Environment.MachineName);
            GroupPrincipal gp = new GroupPrincipal(ctx);
            gp.Name = "*";
            PrincipalSearcher ps = new PrincipalSearcher();
            ps.QueryFilter = gp;
            PrincipalSearchResult<Principal> result = ps.FindAll();
            if(result.Count() > 0)
            {
                localGroups = new List<LocalGroup>();
                foreach (Principal p in result)
                {
                    LocalGroup g = new LocalGroup();
                    g.groupName = p.Name;
                    g.users = GetGroupMembers(g.groupName);
                    localGroups.Add(g);
                }
            }
        }
    }
    public class LocalGroup
    {
        public string groupName { get; set; }
        public List<String> users { get; set; }
    }
