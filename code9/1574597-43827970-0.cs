    string id = await context.Users
        .Where(w => w.UserName == un)
        .Select(w => w.Id)
        .FirstOrDefaultAsync();
    na.Users.Add(new User { Id = id }); // <- This is incorrect.
