    var Users = context.Users.Where(r => r.IsDeleted == IsDeleted).ToList<User>();
    
    if(condition)
    {
        Users = Users.where(y => y.IsDeleted == false)).ToList();
    }
