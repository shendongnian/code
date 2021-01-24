    // using Z.EntityFramework.Plus; // Don't forget to include this.
    
    // UPDATE all users inactive for 2 years
    var date = DateTime.Now.AddYears(-2);
    ctx.Users.Where(x => x.LastLoginDate < date)
             .UpdateAsync(x => new User() { IsSoftDeleted = 1 });
