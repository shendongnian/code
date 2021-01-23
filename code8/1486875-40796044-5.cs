    namespace PositiveOrNegative
    {
      class Program
      {
        static void Main(string[] args)
        {
          for(int lineNumber = 0; lineNumber < 4; lineNumber++)
          {
            int NumberOfSpaces = 5 - lineNumber - 1;
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
