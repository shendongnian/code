    foreach (RoleDto role in userRoles)
                {
                    var UserRole = new UserRole();
                    UserRole.RoleId = role.Id;
                    UserRole.UserId = userId;
                    unitOfWork.UserRoles.Attach(UserRole);
                    unitOfWork.Entry(UserRole).State = EntityState.Deleted;
                }
                unitOfWork.SaveChanges();
