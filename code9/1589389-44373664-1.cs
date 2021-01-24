    // following method will insert new record into the database. 
    
        public void CreateUser(user data){
        _ctxmain = new UserDbContext();
        var newUser = new user {
        UserId = data.UserId,
        Name = data.Name,
        CreatedAt = data.CreatedAt,
        CreatedBy = data.CreatedBy,
        modifiedBy = data.modifiedBy,
        modifiedAt = data.modifiedAt,
        address = data.address,
        city = data.city
        
        };
        
        _ctxmain.User.Add(newUser);
        _ctxmain.SaveChanges();  // saving details to the User table in database
        
        }
