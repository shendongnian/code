    var query = context.Users;
    switch (userOrder)
    {
        case UserOrder.RegistDate:
            query = query.Orderby(a => a.RegistrationDate);
            break;
        case UserOrder.A_Z:
            query = query.Orderby(a => a.UserName);
            break;
        case UserOrder.Z_A:
            query = query.OrderbyDescending(a => a.UserName);
            break;
        case UserOrder.MostComment:
            query = query.Orderby(a => a.Comments.Count);
            break;
    }
    IEnumerable<AppUser> results = query
        .Select(a => new AppUser
        {
            UserName = a.UserName,
            Id = a.Id,
            Email = a.Email,
            EmailConfirmed = a.EmailConfirmed,
            RegistrationDate = a.RegistrationDate
        })
        .ToList();
