    myDbContext.Users
    .Select(u => new
    {
        u.UserId,
        u.FirstName,
        u.LastName,
        Age = u.Exceptions.Any() ? u.Exceptions.FirstOrDefault().Age : u.Details.FirstOrDefault().Age
    })
