    using System;
    
    namespace Convo-
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                StartConversation();
            }
            private static void StartConversation()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Friend- How is your day going?");
                Console.WriteLine(" ");
                Console.WriteLine("You- Good = 1" +
                    " / Bad = 2");
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.KeyChar == '1')
    
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Friend- That's very nice!");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Friend- Im sorry is there anything I can do?");
                }
    
                Console.WriteLine(" ");
                Console.WriteLine("(Don't like your choice go back by clicking 3)");
    
                bool running = true;
    
    
              if (keyinfo.KeyChar == '3')
                {
                    //here is where i need the go back function
                    StartConversation();
                }
    
            }
        }
    }
