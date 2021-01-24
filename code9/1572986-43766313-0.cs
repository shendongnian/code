    static void Main(string[] args)
    {
        do
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                Console.WriteLine(key.Key);
            }
            else
            {
                Console.WriteLine("No key pressed");
            }
            System.Threading.Thread.Sleep(100);
        } while (true);
    }
