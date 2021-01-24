      static void Main(string[] args)
      {
         // important!!!
         Console.TreatControlCAsInput = true;
         while (true)
         {
            Console.WriteLine("Use CTRL+C to exit");
            var input = Console.ReadKey();
            if (input.Key == ConsoleKey.C && input.Modifiers == ConsoleModifiers.Control)
            {
               break;
            }
         }
         // Cleanup
         // Server?.Dispose();
      }
