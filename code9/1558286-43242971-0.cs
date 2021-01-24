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
            WriteLine("Please enter a number between one and five");
            response = Convert.ToInt32(ReadLine());
            if (response>=1 && response<=5)
            {
               Console.Writeline(quote[response-1]);
            }
        }
    }
