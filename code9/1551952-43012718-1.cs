    public interface IAttribute
    {
        string AttributeName { get; }
        AttributeCategory Category { get; }
        int Value { get; }
    }
    public abstract class AttributeBase : IAttribute
    {
        protected virtual string AttributeName { get; }
        protected virtual AttributeCategory Category { get; }
        protected virtual int Value { get; }
    }
    
    // Note: one might want to implement a generic type for value, something like AttributeBase<T> {... T Value { get; } }
