    using System.Linq;
    [AttributeUsage(AttributeTargets.Class)]
    public class FooAttribute : Attribute
    {
        private readonly string name;
        public FooAttribute(string name)
        {
            this.name = name;
        }
    }
    [Foo("bar")]
    public class Base { }
    public class Child : Base { }
    Console.WriteLine(typeof(Base).CustomAttributes.Count());  // Prints 1.
    Console.WriteLine(typeof(Child).CustomAttributes.Count()); // Prints 0.
