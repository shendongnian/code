    interface IMyType
    {
       //...what ever method/properties are shared for all
    }
    public class MyType<T> : IMyType
    {
       public T getValue() { return value; }
       //...shared methods
    }
    public class MyTypeOtherSide : IMyType
    {
       //...shared methods
    }
