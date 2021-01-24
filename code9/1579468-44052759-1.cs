    public void ChangeFldPerms2()
    {
        SharePoint.ClientContext _ClientContext = new _SharePoint.ClientContext("https://sharepoint.oshiro.com/sites/oshirodev/");
        _ClientContext.Credentials = new NetworkCredential("user", "pass", "oshiro.com");
        _SharePoint.Principal _user = _ClientContext.Web.EnsureUser(@"oshiro\tom");
        var list = _ClientContext.Web.Lists.GetByTitle("Library1");
        var folderItem = list.LoadItemByUrl("/sites/oshirodev/Library1/Folder1");
        var roleDefinition = _ClientContext.Site.RootWeb.RoleDefinitions.GetByType(_SharePoint.RoleType.Reader);
        var roleBindings = new _SharePoint.RoleDefinitionBindingCollection(_ClientContext) { roleDefinition };
        folderItem.BreakRoleInheritance(true, false);
        folderItem.RoleAssignments.Add(user, roleBindings);
    
        _ClientContext.ExecuteQuery();
    }
