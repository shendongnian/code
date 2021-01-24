    using (var context = GetDbContext())
    {
        return context.Clients.Select(cli => new YourViewModel
        {
            Name = cli.FullName,
            // Other prop setters go here
            CardCount = cli.Cards.Count
        }).Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }
