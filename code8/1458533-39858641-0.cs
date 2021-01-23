    Context.DbSet<User>.Select(user => new // note, anonymous type here
    {
       Name = user.FirstName + ", " + user.LastName,
       Email = user.Email,
       Statuses = user.Statuses.Select(status => status.Name), // no ToList - this won't work
       Groups = user.Groups.Select(group => new GroupModel(){ Name = group.Name, Type = group.Type.Name}), // no ToList()
       OfficeStates = user.Offices.Select(office => office.State.Abbreviation) // no ToList(), no String.Join()
    }).ToList() // here we materizized, and now we can concatenate strings by hand
    .Select(c => new UserReport {
         Name = c.Name,
         Email = c.Email,
         Statuses = c.Statuses.ToList(),
         Groups = c.Groups.ToList(),
         OfficeStates = String.Join(",", c.Offices)
    });
