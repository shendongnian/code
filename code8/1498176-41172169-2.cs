    public class Hello1
    {
        public static void Main()
        {
            PrintToConsole("Hello World!", 5);
    
            // This is here only to pause the console window so it stays open.
            System.Console.ReadLine();
        }
    
        private static void PrintToConsole(string stringToPrintToConsole, long numberOfTimesToPrint)
        {
            for (int i = 0; i < numberOfTimesToPrint; i++)
            {
                System.Console.WriteLine(stringToPrintToConsole);
            }
        }
    }
