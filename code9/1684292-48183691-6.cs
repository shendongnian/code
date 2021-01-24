    var result = myDbContext.Users
        .Where(user => user.Name = ...)
        .Select(user => new
        {   // get only the properties you plan to use:
            Name = user.Name,
            ...
            // only if you also need some account properties:
            Account = new
            {
                Email = user.Account.Email,
                Password = user.Account.Password,
                ...
            },
         });
                
