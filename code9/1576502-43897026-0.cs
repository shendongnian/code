    class Program
    {
        enum FizzBuzz
        {
            None,
            Fizz,
            Buzz,
            FizzBuzz
        }
        static void Main(string[] args)
        {
            // Declare the map
            Dictionary<(bool, bool), FizzBuzz> matchMap =
                new Dictionary<(bool, bool), FizzBuzz>
                {
                    {  (false, false), FizzBuzz.None },
                    {  (true, true), FizzBuzz.FizzBuzz },
                    {  (true, false), FizzBuzz.Fizz },
                    {  (false, true), FizzBuzz.Buzz },
                };
            // Demonstration of the map
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine($"i: {i}, (i % 3 == 0, i % 5 == 0): {matchMap[(i % 3 == 0, i % 5 == 0)]}");
            }
        }
    }
