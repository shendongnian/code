    class Foo
        {
            public Foo()
            {
                Console.WriteLine("Constructed");
            }
    
            ~Foo()
            {
                Console.WriteLine("Destructed");
            }
        }
