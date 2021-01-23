    public interface IObject
    {
        int ID {get; set;}
    }
    public class MyObject : IObject
    {
        public int ID {get; set;}
        //other properties.
    }
    public void AddItem(TEntity item): where TEntity:IObject
    {
        var entities = GetAllItems().ToList(); //Method gets cached IEnumerable<TEntity>
        if(!objects.Any(a=> a.ID == item.ID ))//Generically see if TEntity is already in the list based of defined properties
        {
            entities.Add(item);
        }
    }
