    public interface IEntity<T>
    {
        Action<T> OnEntityDisable { get; set; }
    }
    public class SelectionList<T> : IList<T> where T : IEntity<T>
    { }
