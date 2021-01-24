    IQueryable<NamRole> mamRolesOfAllUsers = myDbContext.Users
        .SelectMany(user => user.MamRoles);
    IQueryable<MamRoleModel> mamUserGroupModelsOfAllUsers = mamRolesOfAllUsers
        .SelectMany(mamRole => mamRole.MamUserGroupModels);
    IQueryable<string> mamUserGroups = mamUserGroupModelsOfAllUsers
        .Select(mamUserGroupModel => mamUserGroupModeModel.MamUserGroup;
