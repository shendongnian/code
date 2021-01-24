    public interface IFoo<T> { }
    public interface IEntity { }
    public class A : IEntity { }
    public class Foo : IFoo<IEntity> { }
    public class FooA : IFoo<A> { }
    public class FooS : IFoo<string> { }
