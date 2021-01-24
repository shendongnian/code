        var users =  dbContext.Users.Select(s => new UserDto
        Id = s.Id,
        Name = s.FullName,
        UserType = s.UserType.Select(t => new UserTypeDto
        {
            Id = t.Id,
            Name = t.Name
        }).ToList()
