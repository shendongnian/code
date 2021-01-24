    public class A { };
    public class B { };
    void Foo()
    {
        var a = new A();
        var b = a.To(x => new B());
    }
