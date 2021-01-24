    var groupedUserRoles = userRoles
        .GroupBy(i => i.UserID)
        .Select(i => new
            {
                UserId = i.Key,
                Roles = i.Select(r => r.RoleName)
            })
        .ToList();
    groupedUserRoles.ForEach(ur => 
        Console.WriteLine($"UserID: {ur.UserId}, Roles: {string.Join(", ", ur.Roles)}"));
