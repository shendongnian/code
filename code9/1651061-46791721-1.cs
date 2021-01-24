     private static void Main(string[] args)
            {
                dynamic foo = new MyExpando();
                if (foo.Boo?.Lol ?? true)
                {
                    Console.WriteLine("It works!");
                }
                Console.ReadLine();
            }
