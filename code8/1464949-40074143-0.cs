    using System;
    
    public class Foo { }
    
    public class Bar
    {
        public static implicit operator Foo(Bar bar) => new Foo();
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            var bar = new Bar();
            var foo = (Foo)bar;
            
            DoSomething(foo);
            DoSomething(bar);
        }
        
        static void DoSomething(dynamic o)
        {
            var foo = (Foo) o;
        }
    }
