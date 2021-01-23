    public interface IEntity
    {
        int Id {get;set}
    }
    public static class Extention 
    {    
        public static Type GetObjectForIdInCollection(this IQueryable<Type> selection, int id) 
             where Type : IEntity
        {
            return selection.FirstOrDefault(c => c.ID == Id);
        }
    }
