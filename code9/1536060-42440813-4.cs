    public interface IContainer
    {
        IList<IComponent> Components { get; }
    }
    public interface IComponent
    {
        // it can be/do anything
    }
