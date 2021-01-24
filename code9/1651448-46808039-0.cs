    // Get the TFS security service.
    var sec = tfs.GetService<ISecurityService>();
    SecurityNamespace sn = sec.GetSecurityNamespace(FrameworkSecurity.TeamProjectNamespaceId);
    string securityToken;
    if (sn.Description.DisplayName == "Project")
    {
       securityToken = "$PROJECT:" + projectUri;
       sn.SetPermissions(securityToken, newGroup, TeamProjectPermissions.AllPermissions, 0, true);
    }
      
