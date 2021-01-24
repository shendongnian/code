    AccessRuleCollection accessRules = item.Security.GetAccessRules();
    AccessRightCollection accessRights = AccessRightManager.GetAccessRights();
    foreach (AccessRight accessRight in accessRights)
    {
        AccessPermission accessPermission =
            accessRules.Helper.GetAccessPermission(account, accessRight, PropagationType.Entity);
        if (accessPermission != AccessPermission.NotSet)
        {
            // do smth here
        }
    }
