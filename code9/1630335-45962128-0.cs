    public class SomeGenericBaseClass<Tx> : IDisposable
        where Tx : class { }
    public class MyClass<Ta, Tb> : IDisposable
        where Ta : SomeGenericBaseClass<Tb>, new()
        where Tb : IDisposable
