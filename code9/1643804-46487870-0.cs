    void Main()
    {
        typeof(A).GetCustomAttributes().Dump(); // both
        typeof(A).GetCustomAttributes(inherit: false).Dump(); // both
        typeof(B).GetCustomAttributes().Dump(); // inheritable
        typeof(B).GetCustomAttributes(inherit: false).Dump(); // none because inheritance is prevented
        typeof(C).GetCustomAttributes().Dump(); // both
        typeof(C).GetCustomAttributes(inherit: false).Dump(); // both because C comes with its own copies
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class InheritableExampleAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class NonInheritableExampleAttribute : Attribute { }
    [InheritableExample]
    [NonInheritableExample]
    public class A { }
    public class B : A { }
    [InheritableExample]
    [NonInheritableExample]
    public class C : A { }
