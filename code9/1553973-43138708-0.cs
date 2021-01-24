    QueryExpression query = new QueryExpression
    {
        EntityName = "role"
    };
    //Get all Security Roles
    EntityCollection Securityroles = organisationservice.RetrieveMultiple(query);
    //Get all Privileges
    RetrievePrivilegeSetRequest requestp = new RetrievePrivilegeSetRequest();
    RetrievePrivilegeSetResponse responsep = (RetrievePrivilegeSetResponse)organisationservice.Execute(requestp);
    foreach (Entity securityrole in Securityroles.Entities)
    {
        //Get record from RolePrivilege Mapping
        RetrieveRolePrivilegesRoleRequest req = new RetrieveRolePrivilegesRoleRequest();
        req.RoleId = new Guid(securityrole.Id.ToString());
        RetrieveRolePrivilegesRoleResponse response = (RetrieveRolePrivilegesRoleResponse)organisationservice.Execute(req);
        foreach (RolePrivilege priv in response.RolePrivileges)
        {
            var privile = responsep.EntityCollection.Entities.Where(a => a.Id == priv.PrivilegeId).ToArray();
        }
    }
