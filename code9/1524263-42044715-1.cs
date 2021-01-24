    // Select all tasks 
    var tasks = roles.Select(role => 
        new { 
            Task = userManager.IsInRoleAsync(user, role.Name),
            Role = role
        }).ToList();
    // Wait for completion
    await Task.WhenAll(tasks.Select(t => t.Task));
    
    // Filter the result and add it to notUserRoles
    notUserRoles.AddRange(tasks
        .Where (t => !t.Task.Result)
        .Select(t =>  t.Role.Name));
