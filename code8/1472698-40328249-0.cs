    context.Users
                .Where(x => x.Roles.Select(y => y.RoleId).Contains("601fd2b9-4a7f-4063-a831-e15978f05657"))
                // Project each user into a DTO which just 
                // UserName property...
                .Select(x => new { UserName = x.UserName })
                .ToList()
