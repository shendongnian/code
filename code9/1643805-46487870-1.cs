    void Main()
    {
    	typeof(A).GetCustomAttributes().Dump("A - inherit: true"); // both
    	typeof(A).GetCustomAttributes(inherit: false).Dump("A - inherit: false"); // both
    
    	typeof(B).GetCustomAttributes().Dump("B - inherit: true"); // inheritable
    	typeof(B).GetCustomAttributes(inherit: false).Dump("B - inherit: false"); // none because inheritance is prevented
    
    	typeof(C).GetCustomAttributes().Dump("C - inherit: true"); // both
    	typeof(C).GetCustomAttributes(inherit: false).Dump("C - inherit: false"); // both because C comes with its own copies
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
