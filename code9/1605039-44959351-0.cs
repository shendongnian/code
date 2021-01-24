    public static class HasDefaultConstructor<T> where T : new() { }
    public class CheckAttribute : Attribute
    {
        public CheckAttribute(Type type) { }
    }
    [Check(typeof(HasDefaultConstructor<MyClass>))]
    public class MyClass
    {
        public MyClass() { }
    }
