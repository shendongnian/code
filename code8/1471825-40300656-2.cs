    public interface IEntity
    {
        int Id { get; set; }
    }
    public static class Extention
    {
        public static Type GetObjectForIdInCollection<Type>(this IQueryable<Type> selection, int id)
             where Type : class, IEntity
        {
            return selection.FirstOrDefault(c => c.Id == id);
        }
    }
