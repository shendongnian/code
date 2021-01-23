    SPGroup group = properties.Web.SiteGroups[grp];
                    
    SPRoleDefinition definition = item.Web.RoleDefinitions.GetByType(SPRoleType.Reader);
    SPRoleAssignmentCollection roles = item.RoleAssignments;
    for (int i = 0; i < roles.Count; i++)
    {
        bool removeThisRole = false;
        SPRoleDefinitionBindingCollection rbc = roles[i].RoleDefinitionBindings;
        foreach (SPRoleDefinition rdef in rbc)
        {
            if (rdef.Type == SPRoleType.Reader)
                removeThisRole = true;
        }
        if (removeThisRole)
        {
            if (!item.HasUniqueRoleAssignments) // required to make role change
                item.BreakRoleInheritance(true);
            item.RoleAssignments.Remove(i);
            item.Update();
            removeThisRole = false;
        }
    }
