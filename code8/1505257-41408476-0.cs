    private static void StartNewGame()
    {
          int maxGetal = 0, maxAantalGissingen = 0;
          string input;
          Console.WriteLine("Raad het getal spel!");
          // Do something 
          GetalSpel game = new GetalSpel(maxAantalGissingen, maxGetal);
          Console.Clear();
          do
          {
              // Do something
          } while (input != "3");
          StartNewGame();  // <--- This is the call to solve the described issue.
    }
