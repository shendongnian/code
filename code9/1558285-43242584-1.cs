    namespace ConsoleApp7
    {
        class Program
        {
            static void Main(string[] args)
            {
                int response;
    
                string[] quotes = new string [5];
                      
    
                {
                    quotes[0] = ("Today is going to be a good day");
                    quotes[1] = ("Tomorrow is going to rain");
                    quotes[2] = ("Next month will be blissful");
                    quotes[3] = ("You are very lucky to be here");
                    quotes[4] = ("The love of your life notices you");
                }
    
                WriteLine("Please enter a number between one and five");
    
                response = Convert.ToInt32(ReadLine());
    
    
                WriteLine(quotes[response]);
