    String GetUserName(String emailAddress) {
        
        IQueryable<User> query = database.Users;
        query = query.Where( u => u.Email == emailAddress );
        
        if( !userHasPermissionToViewAllUsers ) {
            query = query.Where( u => u.UserId == currentUserUserId );
        }
        return query.FirstOrDefault()?.UserName;
    }
