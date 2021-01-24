     public static int GetInput(string displayMessage)
     {
         Console.ForegroundColor = ConsoleColor.Cyan;
         Console.WriteLine(displayMessage);
         Console.ResetColor();
         return int.Parse(Console.ReadLine());
     }
