        static void Main(string[] args)
        {
            int? bob = null;
            Test(bob);
        }
        private static void Test<T>(T bob)
        {
            Console.WriteLine(bob is T);
            Console.WriteLine(typeof(T).IsInstanceOfType(bob));
            Console.WriteLine(typeof(T).IsAssignableFrom(bob.GetType()));
            Console.ReadLine();
        }
