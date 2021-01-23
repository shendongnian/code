    var securityObjects = await context.SecurityObjects.Where(so => so.SecurityPermissions.Any(sp => sp.SecurityRoles.Any(sr => sr.Accounts.Any(a => a.ID == accountId)))).ToListAsync().COnfigureAwait(false);
    var securityPermissionsByObjectId = (await context.SexurityPermissions.Where(sp =>sp.SecurityRoles.Any(sr => sr.Accounts.Any(a => a.ID == accountId))).ToListAsync().ConfigureAwait(false)).GroupBy(sp => sp.SecurityObjectID).ToDictionary(g => g.Key, g => g.Select(sp => sp.Name).ToList());
    
    var result = securityObjects.Select(so => new AuthObject
    {
        Obj = so.Name,
        Permissions = securityPermissionsByObjectId[so.ID]
    })
    .ToList();
    return result;
