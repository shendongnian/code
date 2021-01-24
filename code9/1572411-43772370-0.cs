    Request projectAdminRequest = new Request("ProjectPermission");
    projectAdminRequest.Workspace = workspaceRef;
    projectAdminRequest.Fetch = new List<string>() {"User", "EmailAddress"};
    projectAdminRequest.Query = Query.And(
        new Query("Project", Query.Operator.Equals, "/project/12345"),
        new Query("Role", Query.Operator.Equals, "Project Admin"));
