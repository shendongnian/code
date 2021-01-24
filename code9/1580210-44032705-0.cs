    int databaseId = 1; // just for example
    DatabaseViewModel model = new DatabaseViewModel
    {
      Database = await Context.Databases.FirstOrDefaultAsync(d => d.Id == databaseId),
      Groups = Context.Groups.OrderBy(g => g.Name).Select(g => new DatabaseGroupViewModel
      {
        Group = g,
        Selected =  g.Databases .Any(db => db.Id == databaseId)
      }).ToList()
    };
