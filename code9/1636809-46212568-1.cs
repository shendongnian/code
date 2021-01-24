        public static void Main(string[] args)
        {
            Console.WriteLine("## start ##");
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("counter: " + i);
                delayAsync(i).Wait();
            }
            Console.WriteLine("## finished ##");
            Console.Read();
        }
