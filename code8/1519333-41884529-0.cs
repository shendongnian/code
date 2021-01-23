    Company company;
    using (Context context = new Context())
    {
        context.Configuration.ProxyCreationEnabled = false;
        company = context.Companies.Include(x => x.Users.Select(u => u.Roles))
                         .SingleOrDefault();
    }
    using (Context context = new Context())
    {
        context.Companies.Add(company);
        
        foreach (var user in company.Users.SelectMany(u => u.Roles)
                                    .Distinct())
        {
            context.Entry(role).State = EntityState.Unchanged;
        }
        
        context.SaveChanges();
    }
