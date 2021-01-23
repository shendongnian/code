    public class Hello1
    {
        public static void Main()
        {
            PrintToConsole("Hello World!");
    
            // This is here only to pause the console window so it stays open.
            System.Console.ReadLine();
        }
    
        private static void PrintToConsole(string stringToPrintToConsole)
        {
            System.Console.WriteLine(stringToPrintToConsole);
        }
    }
