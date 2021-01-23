    protected override void Seed(ApplicationDbContext context)
    {
        context.Teams.AddOrUpdate(
            team => team.Id,   // put the key or unique field here
            new Team
            {
                Id = 1,
                Name = "Team 1"
            },
            new Team
            {
                Id = 2,
                Name = "Team 2"
            });
    
        context.SaveChanges();
    }
