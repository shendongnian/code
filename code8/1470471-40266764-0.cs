    using (YourDbContext context = new YourDbContext()) {
        int id = 1;
        var results = (from person in context.People
                       where person.Id == id
                       select new {
                           Person = person,
                           CurrentJob = person.Job.Where(j => j.IsCurrent).FirstOrDefault(),
                           CurrentAddress = person.Address.Where(a => a.IsCurrent).FirstOrDefault()
                       });
    }            
