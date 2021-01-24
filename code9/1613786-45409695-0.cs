    public interface IIdentifiable<T>
        where T : IEquatable<T>
    {
        T Id { get; set; }
    }
