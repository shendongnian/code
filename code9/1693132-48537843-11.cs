    var directoryRoles = await graphClient.DirectoryRoles.Request().GetAsync();
    var userRoles = await graphClient.Me.MemberOf.Request().GetAsync();
    var adminRole=directoryRoles.Where(role => role.DisplayName== "Company Administrator" || role.DisplayName == "Global Administrator").FirstOrDefault();
    if (userRoles.Count(role => role.Id == adminRole.Id) > 0)
    {
        context.AuthenticationTicket.Identity.AddClaim(new Claim(context.AuthenticationTicket.Identity.RoleClaimType, "admin"));
    }
    else
    {
        context.AuthenticationTicket.Identity.AddClaim(new Claim(context.AuthenticationTicket.Identity.RoleClaimType, "user"));
    }
