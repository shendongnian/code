    using (var context = new DbC())
    {
        var teamIds = entity.Teams.Select(t => t.Id).ToArray();
        entity.Teams.Clear();
        context.Entry(entity).State = EntityState.Modified;
        context.Entry(entity).Collection(u => u.Teams).Load();
        entity.Teams.Clear();
        foreach (var teamId in teamIds)
        {
            entity.Teams.Add(context.Teams.Find(teamId));
        }
        return context.SaveChanges();
    }
