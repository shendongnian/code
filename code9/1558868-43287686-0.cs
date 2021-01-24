    public static T GetById<T>(DbSet<T> dbset, int id)
        where T : EntityBase
    {
        return dbset.FirstOrDefault(e => e.Id == id);
    }
    // example
    var entity = GetById(db.Set<IdEntity>(), 2);
