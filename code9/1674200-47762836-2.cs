    public interface IIdentifiable<T>
    {
        T Identifier { get; }
    }
    public abstract class IdentifiableBase<T> : IIdentifiable<T>
    {
        T Identifier { get; protected set; } 
    }
