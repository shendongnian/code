    public static class ConsoleEx
    {
        public static T ReadLine<T>(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
