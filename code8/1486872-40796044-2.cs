    namespace PositiveOrNegative
    {
      class Program
      {
        static void Main(string[] args)
        {
          int lineNumber = 0;
          for(int lineNumber = 1; lineNumber < 6; lineNumber++)
          {
            int NumberOfSpaces = 5 - lineNumber;
            int NumberOfStars = 2 * lineNumber + 1;
            for(int space = 0; space < NumberOfSpaces; space++)
            {
              Console.Write(" ");
            }
            for(int star = 0; star < NumberOfStars; star++)
            {
              Console.Write("*");
            }
            Console.WriteLine();
          }
          Console.ReadKey();
        }
      }
    }
