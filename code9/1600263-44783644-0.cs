    protected override void Seed(f1app.Data.F1appContext context)
        {
            context.Teams.AddOrUpdate(
                t => t.TeamName, DummyData.getTeams().ToArray());
            context.SaveChanges(); // <----------------------
            context.Drivers.AddOrUpdate(
                d => new { d.FirstName, d.LastName }, DummyData.getDrivers(context).ToArray());
            //should be here:
            context.SaveChanges(); // <----------------------
        }
