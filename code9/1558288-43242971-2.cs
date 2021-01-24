    class Program
    {
        static void Main(string[] args)
        {
            int response;
            string[] quotes = new string[]
            {
                "Today is going to be a good day",
                "Tomorrow is going to rain",
                "Next month will be blissful",
                "You are very lucky to be here",
                "The love of your life notices you"
            };
            Console.WriteLine("Please enter a number between one and five");
            
            response=Convert.ToInt32(Console.ReadLine());
            if (response>=1&&response<=5)
            {
                Console.WriteLine(quotes[response-1]);
            }
            else
            {
                Console.WriteLine("Value entered not within expected range");
            }
        }
    }
