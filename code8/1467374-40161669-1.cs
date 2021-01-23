    // LINQ-to-Entities
    var users = await _context.UserContacts
        .Where(uc => uc.UserId == user.Id)
        .Select(uc => new
        {
          uc.Contact.Email,
          uc.Contact.UserId,
          ContactId = uc.Contact.Id,
        })
        .ToListAsync();
    // LINQ-to-Objects
    var lookupTasks = users.Select(async u => new
        {
          u.Email,
          u.UserId,
          u.ContactId,
          Name = u.UserId != null ? await _graphService.GetUserByIdAsync(u.UserId) : null;
        });
    return await Task.WhenAll(lookupTasks);
