      foreach (string[] line in loggBoken)  {
        foreach(string item in line) {
          Console.Write(item);
          Console.Write('\t');
        }
    
        Console.WriteLine();
      }
