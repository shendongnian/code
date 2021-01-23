    public static void Zin(string zin)
    {
         foreach (char c in zin)
         {
              Console.Write(c);
    
              // Only wait when no key has been pressed
              if (!Console.KeyAvailable)
              {
                   Thread.Sleep(50);
              }
         }
    
         // When keys have been pressed during our string output, read all of them, so they are not used for the following input
         while (Console.KeyAvailable)
         {
              Console.ReadKey(true);
         }
    }
