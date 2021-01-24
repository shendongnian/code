    namespace StaticClasses
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Foo(); // Cannot create an instance of the static class 'Foo'
                new Foo.Bar(); // Cannot create an instance of the static class 'Foo.Bar'
                new Foo.Baz();
            }
        }
    
        static class Foo
        {
            public static class Bar
            {
    
            }
    
            public class Baz
            {
    
            }
        }
    }
