    ctx.Users.Select(e => new
                {
                    e.Id,
                    e.UserName,
                    e.Email,
                    e.PhoneNumber,
                    Roles = e.UserRoles.Select(i => i.Role.Name).ToList()
                }).ToList();
