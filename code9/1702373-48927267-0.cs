      private static int ReadInt(string prompt) {
        while (true) {
          Console.WriteLine(prompt);
          int result;
          if (int.TryParse(Console.ReadLine(), out result))
            return result;
          Console.WriteLine("Sorry, it's not a correct integer value, please try again.");
        }
      }
      ...
      public void Multi() {
        Console.Write("Display the multiplication table:\n ");
        // Now we keep asking user until the correct value entered 
        int t = ReadInt("Start value");
        ...
      } 
