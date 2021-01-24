    public class ConsoleRead : IReader
    {
        public ReadResult Read()
        {
            var key = Console.ReadKey(true);
            return new ReadResult(key.KeyChar, key.Key == ConsoleKey.Escape);
        }
    }
