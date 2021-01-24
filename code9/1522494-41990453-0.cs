    var list = db.WorkRoles.
                Join(db.WorkRolesUsersDetails,
                o => o.WorkRoleId, od => od.WorkRoleId,
                (o, od) => new RoleViewModel(
                    o.WorkRoleId,
                    o.RoleName,
                    o.RoleDescription,
                    o.CompanyId,
                    od.WRUDId,
                    od.UserDetailsId,
                    od.FocusStart,
                    od.FocusEnd
                )).ToList();
