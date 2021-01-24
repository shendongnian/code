    using System;
    using System.Linq;
    
    namespace SandboxConsole
    {
        class Program
        {
            private int _test;
            static void Main(string[] args)
            {
                var server = new FairDiceRollServer();
                var hash = server.StartSession();
                Console.WriteLine(string.Join("", hash.Select(x => x.ToString("X"))));
                for (int i = 0; i < 10; i++)
                {
                    var roll = server.RollDice("My Key");
                    Console.WriteLine("Message: {0} Result: {1}", roll.HmacMessage, roll.Roll);
                }
                var key= server.EndSession();
                Console.WriteLine(string.Join("", key.Select(x => x.ToString("X"))));
                Console.ReadLine();
            }
            
        }
    }
