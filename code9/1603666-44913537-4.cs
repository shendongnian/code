     private static void Main(string[] args)
            {
                var foo = new Foo();
                foo.DoSomething(1);
                foo.IamNotLogged();
                foo.IamLoggedToo();
                Console.ReadLine();
            }
