    public interface ISpecification 
    {
        bool IsAsynchronous { get; }
        bool IsSatisfiedBy(object o);
    }
