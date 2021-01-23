    using (YourDbContext context = new YourDbContext()) {
        int id = 1;
        var results = (from person in context.People
                       where person.Id == id
                       select new {
                           Person = person,
                           CurrentJob = person.Job.FirstOrDefault(j => j.IsCurrent),
                           CurrentAddress = person.Address.FirstOrDefault(a => a.IsCurrent)
                       });
    }            
