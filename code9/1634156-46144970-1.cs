    while (true)
    {
        try
        {
            model.SaveChanges();
            break;
        }
        catch (DbUpdateException e)
        {
            foreach (var entry in e.Entries)
            {
                // Do some logic or fix
                // or just detach
                entry.State = System.Data.Entity.EntityState.Detached;
            }
        }
    }
