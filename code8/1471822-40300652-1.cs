    public interface IIdObject
    {
        int Id { get; set; }    
    }
    
    // ...
    
    public T GetObjectForIdInCollection<T>(IQueryable<T> selection, int id)
        where T : IIdObject
    {
        return selection.FirstOrDefault(c => c.Id == id);
    }  
