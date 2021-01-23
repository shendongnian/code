    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new Bar();
            // Works
            Bar obj2 = obj1.WithSomeProp();
            // Won't compile because obj1 returns Bar.
            Foo obj3 = obj1.WithSomeProp();
        }
    }
