    public interface IEntity<T>
    {
        T Id { get; }
    }
    public class Entity<T> : IEntity<T>
    {
        dynamic Item { get; }
        string PropertyName { get; }
        public Entity(dynamic element,string propertyName)
        {
            Item = element;
            PropertyName = propertyName;
        }
        public T Id
        {
            get
            {
                return (T)Item.GetType().GetProperty(PropertyName).GetValue(Item, null);
            }
        }
    }
