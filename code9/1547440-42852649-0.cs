                foreach (RoleDto role in userRoles)
            {
                var UserRole = new UserRole();
                UserRole.RoleId = role.Id;
                UserRole.UserId = userId;
                usersAllRoles.Add(UserRole);
                unitOfWork.UserRoles.Attach(UserRole);
            }
            // Delete user role
            unitOfWork.UserRoles.RemoveRange(usersAllRoles);
