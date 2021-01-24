    using System;
    
    namespace ConsoleApp1
    {
        internal static class Program
        {
            private static readonly Random Random = new Random();
    
            private static void Main(string[] args)
            {
                Console.CursorVisible = false;
    
                while (true)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                        break;
    
                    Console.SetCursorPosition(10, 10);
                    Console.Write(GetString());
                }
            }
    
            private static char GetChar()
            {
                return (char) Random.Next(65, 92);
            }
    
            private static string GetString()
            {
                return $"{GetChar()}{GetChar()}{GetChar()}{GetChar()}{GetChar()}";
            }
        }
    }
