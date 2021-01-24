    permissionToUpdate.UserPermissions
        .Except(permission.UserPermissions)
        .ToList()
        .ForEach(x => permissionToUpdate.UserPermissions.Remove(x));
    permission.UserPermissions
        .Except(permissionToUpdate.UserPermissions)
        .ToList()
        .ForEach(x => permissionToUpdate.UserPermissions.Add(x));
