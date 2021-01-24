    var groupedUserRoles = userRoles
        .GroupBy(ur => ur.UserID)
        .Select(ur => new
            {
                UserId = ur.Key,
                Roles = ur.Select(r => r.RoleName)
            })
        .ToList();
    groupedUserRoles.ForEach(ur => 
        Console.WriteLine($"UserID: {ur.UserId}, Roles: {string.Join(", ", ur.Roles)}"));
