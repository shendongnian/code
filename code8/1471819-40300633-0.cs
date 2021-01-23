    public T GetObjectForIdInCollection<T>(IQueryable<T> selection, int id)
        where T : BaseEntity
    {
        return selection.Where(c => c.ID == id).FirstOrDefault();
         
        // Or you can simply use:
        // return selection.FirstOrDefault(c => c.ID == id);
    } 
