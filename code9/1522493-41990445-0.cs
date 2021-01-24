    <code>
    var list = db.WorkRoles.
                    Join(db.WorkRolesUsersDetails,
                    o => o.WorkRoleId, od => od.WorkRoleId,
                    (o, od) => new
                    {
                        WorkRoleId = o.WorkRoleId,
                        RoleName = o.RoleName,
                        RoleDescription = o.RoleDescription,
                        CompanyId = o.CompanyId,
                        WRUDId = od.WRUDId,
                        UserDetailsId = od.UserDetailsId,
                        FocusStart = od.FocusStart,
                        FocusEnd = od.FocusEnd
                    }).ToList()
                    .Select(item => new RoleViewModel(
                       item.WorkRoleId,
                        item.RoleName,
                        item.RoleDescription,
                        item.CompanyId,
                        item.WRUDId,
                        item.UserDetailsId,
                        item.FocusStart,
                        item.FocusEnd));
    </code>
