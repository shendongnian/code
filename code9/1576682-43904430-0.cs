    public interface IMap<S, T>
    {
        T Map(S source);
    }
    public class SomeClass { }
    public class ThatClass { }
    public interface IMapOfSomething : IMap<SomeClass, ThatClass> { }
    public class Map : IMapOfSomething
    {
        ThatClass IMap<SomeClass, ThatClass>.Map(SomeClass source)
        {
            throw new NotImplementedException();
        }
    }
