    public class SomeGenericBaseClass<Tx> : IDisposable
        where Tx : class { }
    public class MyClass<Ta> : IDisposable
        where Ta : SomeGenericBaseClass<string>, new()
    var obj = new MyClass<SomeConcreteClass>();
