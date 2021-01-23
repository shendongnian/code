    private static void PrintAnswer(string noun, string verb, string adjective) {
      Console.Write("A ");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write(noun);
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(" likes to eat a lot. It likes to ");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write(verb);
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(" in the ");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write(adjective);
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine(" looking water.");
      Console.ResetColor();
    }
