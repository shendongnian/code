    return officeIDs != null
                        ? (from user in GetDBContext.User
                            join userRole in GetDBContext.UserRole
                            on user.UserID equals userRole.UserID
                            join userOffice in GetDBContext.UserAuthorizedOffice
                            on user.UserID equals userOffice.UserID
                            where user.IsActive == true &&
                                  user.UserTypeID == 1 &&
                                  userOffice.IsAuthorized &&
                                  userOffice.Office.IsActive &&
                                  officeIDs.Contains(userOffice.Office)
                                  string.Equals(userRole.RoleID, roleID) &&
                                  (user.FirstName + user.LastName).Contains(query)
                            select user).ToList();
                        : (from user in GetDBContext.User
                            join userRole in GetDBContext.UserRole
                            on user.UserID equals userRole.UserID
                            join userOffice in GetDBContext.UserAuthorizedOffice
                            on user.UserID equals userOffice.UserID
                            where user.IsActive == true &&
                                  user.UserTypeID == 1 &&
                                  userOffice.IsAuthorized &&
                                  userOffice.Office.IsActive &&
                                  string.Equals(userRole.RoleID, roleID) &&
                                  (user.FirstName + user.LastName).Contains(query)
                            select user).ToList();
