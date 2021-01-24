    public void AddUpdate<T>(T obj) where T : IEntity
    {
        using(var ctx = new ClsContext(_ConnectionString))
        {
            if (obj.keyID == 0)
            {
                ctx.Entry(o).State = EntityState.Added;
            }
            else
            {
                ctx.Entry(o).State = EntityState.Modified;
            }
            ctx.SaveChanges();
        }
    }
    public interface IEntity
    {
        int keyId {get;set;}
    }
