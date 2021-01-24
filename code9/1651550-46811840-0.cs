    public interface IPrototype
    {
        Guid Id { get; set; }
        string Name{ get; set; }
    }
    
    public interface IHierarchicalPrototype<T> : IPrototype where T:IPrototype
    {
        T Parent{ get; }
        IList<T> Children { get; }
    }
