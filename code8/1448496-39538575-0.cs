    // Filter, sort, project it into an anonymous type and get the data as a list
    var users = await allUsers.OrderBy(user => user.FirstName)
                                 .Select(user => new 
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DisplayName = user.DisplayName,
            Email = user.Email,
            Enabled = user.Enabled
        }).ToListAsync();
    // now that we have the data, we iterate though it and 
    // fetch the roles
    var userViewModels = users.Select(async user => new UsersViewModel
    {
        Id = user.Id,
        UserName = user.UserName,
        FirstName = user.FirstName,
        LastName = user.LastName,
        DisplayName = user.DisplayName,
        Email = user.Email,
        Enabled = user.Enabled,
        Roles = string.Join(", ", await _userManager.GetRolesAsync(user))
    });
