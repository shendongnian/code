    var result = dbContext.Users
        .Where(user => user.Sign == X)
        .Select(user => new
        {   // select only the properties you'll use after the query
            ...
            // from the Profile, select only the properties you'll use after the query
            Profiles = user.Profile.Select(profile => new
            {
                 ...
            }
        });
