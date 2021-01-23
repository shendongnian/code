    class Program
    {
        static void Main(string[] args)
        {
            var myKey = Key<string>.Make("StringKeyValue");
            Console.WriteLine($"String Key is {myKey.Value}");
            var otherKey = Key<int>.Make(23);
            Console.WriteLine($"integer Key is {otherKey.Value}");
            try {var badTypKey = Key<DateTime>.Make(DateTime.Now); }
            catch (TypeAccessException x)
            { Console.WriteLine($" Got TypeAccessException {x.Message}"); }
            Console.WriteLine("Hit any key to terminate.");
            Console.ReadLine();
        }
    }
