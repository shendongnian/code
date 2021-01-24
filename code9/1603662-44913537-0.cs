     [Inpectable]
        internal class Foo : ContextBoundObject
        {
            [InspectableProperty]
            public int DoSomething(int a)
            {
                Console.WriteLine("I am doing something");
                a += 1;
                return a;
            }
    
            public void IamNotLogged()
            {
                Console.WriteLine("Lol");
            }
    
            [InspectableProperty]
            public string IamLoggedToo()
            {
                var msg = "Lol too";
                Console.WriteLine(msg);
                return msg;
            }
        }
