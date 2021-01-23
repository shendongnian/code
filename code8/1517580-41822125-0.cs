    public List<User> GetActiveUsers(IEnumerable<int> officeIDs, string roleID, string query)
        {
    		officeIDs = officeIDs ?? new List<int>();
    	
            return (from user in GetDBContext.User
                    join userRole in GetDBContext.UserRole
                        on user.UserID equals userRole.UserID
                    join userOffice in GetDBContext.UserAuthorizedOffice
                        on user.UserID equals userOffice.UserID
                    where user.IsActive == true &&
                            user.UserTypeID == 1 &&
                            userOffice.IsAuthorized &&
                            userOffice.Office.IsActive &&
                            officeIDs.Contains(userOffice.OfficeID) &&
                            string.Equals(userRole.RoleID, roleID) &&
                            (user.FirstName + user.LastName).Contains(query)
                    select user).ToList();
        }
