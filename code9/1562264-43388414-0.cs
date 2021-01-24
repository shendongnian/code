    var test = _context.SomeDatabaseTable
                       .ToList()
                       .Select(c => new SomeViewModel
                       {
                           AssignedUsers = c.AssignedToUserIDs.Split(';')
                       });   
