    //get the TabPermission for the current tab and cast from Collection to List<TabPermissionInfo>
    List<DotNetNuke.Security.Permissions.TabPermissionInfo> tabPermissionInfo = DotNetNuke.Security.Permissions.TabPermissionController.GetTabPermissions(TabId, PortalId).Cast<DotNetNuke.Security.Permissions.TabPermissionInfo>().ToList();
    
    //loop all the permissionInfo objects and check for RoleId -1 (= all users)
    bool allUsers = false;
    foreach (TabPermissionInfo permissionInfo in tabPermissionInfo)
    {
        if (permissionInfo.RoleID == -1)
        {
            allUsers = true;
        }
        //for visualization of all roles and id's for current tab
        Label1.Text += permissionInfo.RoleName + " - " + permissionInfo.RoleID + "<br>";
    }
