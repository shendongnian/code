    class Program
    {
        static void Main(string[] args)
        {
            string[] quotes = new string[]
            {
                "Today is going to be a good day",
                "Tomorrow is going to rain",
                "Next month will be blissful",
                "You are very lucky to be here",
                "The love of your life notices you"
            };
            int response;
            int.TryParse(Console.ReadLine(), out response);
            if (response>=1&&response<=quotes.Length)
            {
                Console.WriteLine(quotes[response-1]);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
