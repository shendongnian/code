    using (var context = GetDbContext())
    {
        context.Clients.Select(cli => new YourViewModel
        {
            Name = cli.FullName,
            // Other prop setters go here
            CardCount = cli.Cards.Count
        }
    }
