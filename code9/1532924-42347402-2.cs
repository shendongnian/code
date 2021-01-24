    // DELETE all users which has been inactive for 2 years
    ctx.Users.Where(x => x.LastLoginDate < DateTime.Now.AddYears(-2))
             .Delete();
    
    // UPDATE all users which has been inactive for 2 years
    ctx.Users.Where(x => x.LastLoginDate < DateTime.Now.AddYears(-2))
             .Update(x => new User() { IsSoftDeleted = 1 });
