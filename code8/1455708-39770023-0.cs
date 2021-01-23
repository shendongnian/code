    internal interface ITyped
    {
        Type Type { get; }
    }
    internal class Typed : ITyped
    {
        public Typed(Type type)
        {
            Type = type;
        }
        public Type Type { get; }
    }
