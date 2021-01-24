    List<ActiveUser> allWithAtLeastOneActiveUser  = userList
        .GroupBy(c => new { c.UserID, c.UserName })
        .Where(g => g.Any(u => u.IsActive))
        .SelectMany(g => g)
        .ToList();
