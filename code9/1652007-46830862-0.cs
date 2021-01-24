    using System;
    
    static class Program
    {
        static void Main()
        {
            var x = new Foo();
            TheThing += x.Bar;
            TheThing?.Invoke();
            TheThing -= x.Bar;
            TheThing?.Invoke();
        }
        static event Action TheThing;
    }
    struct Foo
    {
        public void Bar() => Console.WriteLine("Hi");
    }
