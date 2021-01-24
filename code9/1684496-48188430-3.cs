    public interface IHierarchy
    {
        public Guid ParentId { get; }
    }
    public static List<T> GetItems<T>(Guid parentId = new Guid()) 
        where T : IHierarchy, new()
    {
        var db = new SQLiteConnection(_dbPath);
        List<T> result;
    
        if (parentId != Guid.Empty)
        {
            result = db.Table<T>().Where(i => i.ParentId.Equals(parentId)).ToList();
        }
        else
        {
            result = db.Table<T>().ToList();
        }
    
        db.Close();
        return result;
    }
