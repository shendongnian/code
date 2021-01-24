    var user=context.Users.FirstOrDefault(r.IsDeleted == IsDeleted);//Getting a user
    
    context.Entry(user) 
            .Collection(b => b.UserRoles) 
            .Query() 
            .Where(y=>!y.IsDeleted)
            .Load(); 
