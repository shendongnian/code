    public SelectList getRoleSelectList()
    {
         IApplicationLogic app = new ApplicationLogic(session);
         var roles = app.GetListOfRoles().OrderBy(x=> x.RoleID);
         return new SelectList(roles.ToList(), "RoleID", "Role");
    }
