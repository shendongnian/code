    using System;
    
    namespace ProjectTicTacToe
    {
      internal class Program
      {
        private static void Main()
        {
          Console.WriteLine("   A B C");
          Console.WriteLine();
    
          string[,] deska =
                {
                    { "1 ", "2 ", "3 " },
                    { "0 ", "0 ", "0" },
                    { "0 ", "0 ", "0" },
                    { "0 ", "0 ", "0" },
                };
    
          int prevLenght = 0;
          int currentLenght = 0;
          for (int i = 0; i < deska.GetLength(0); i++)
          {
            currentLenght += prevLenght;
            for (int j = 0; j < deska.GetLength(1); j++)
            {
              Console.SetCursorPosition(currentLenght, Console.CursorTop);
              prevLenght = deska[i, j].Length + 1;
              Console.WriteLine(deska[i, j]);
            }
    
            Console.CursorTop -= deska.GetLength(1);
          }
          Console.ReadKey();
        }
      }
    }
