    public void Commit()
    {
        using (var context = new ApplicationDbContext())
        {
                context.UpdateRange(Changed);
                context.AddRange(Added);
                context.RemoveRange(Deleted);
                
                context.SaveChanges();
                ClearAllChanges();
        }
    }
