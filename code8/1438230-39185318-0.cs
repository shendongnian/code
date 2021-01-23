    class VersionTest
    {
      void Test()
      {
        Console.Write("Executing assembly: {0}\n", Assembly.GetExecutingAssembly().GetName().ToString()); // returns AssemblyA
        Console.Write("Entry assembly: {0}\n", Assembly.GetEntryAssembly().GetName().ToString());         // returns AssemblyB
      }
    }
