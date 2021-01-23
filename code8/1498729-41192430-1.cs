    ...
    originalModel.Email = model.ApplicationUser.Email;
    userRole.RoleId = model.ApplicationRole.Id;
    ApplicationDbContext.Users.Attach(originalModel);  // <--- Delete this line
    ApplicationDbContext.UserRoles.Attach(userRole);  // <--- Delete this line
    ApplicationDbContext.Entry(originalModel).State = EntityState.Modified;  // <--- Delete this line
    if (await ApplicationDbContext.SaveChangesAsync() == 0)
    ...
