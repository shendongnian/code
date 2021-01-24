    Principal entity = ctx.Web.EnsureUser(item["user"]);
    roleAssignment = myList.RoleAssignments.GetByPrincipal(entity);
    roleAssignment.ImportRoleDefinitionBindings(colRoleDefinitionBinding);
    roleAssignment.Update();
    ctx.ExecuteQuery();
