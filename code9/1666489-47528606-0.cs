    var userId = .... // Obtained elsewhere
    using (var context = new DbContext())
    {
        var user =
            context.Set<User>()
                .Include(u => u.Person.Employee)
                .Where(u => u.Id == userId)
                .ToList()
                .FirstOrDefault();
    }
