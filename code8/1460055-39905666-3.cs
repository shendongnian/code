    class Program
    {
        static void Main(string[] args)
        {
            var _random = new Random();
            Func<int> func = () =>
            {
                var result = _random.Next(10);
                Console.WriteLine(result);
                return result;
            };
            Retry.Do(func, TimeSpan.FromSeconds(1), i => i == 5);
            Console.ReadLine();
        }
    }
