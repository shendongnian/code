    using System;
    using RdRandWrapper;
    
    class Program {
      static void Main(string[] args) {
        var r = new RdRandom();
        for (int i = 0; i != 10; ++i) {
          Console.WriteLine(r.Next());
        }
      }
    }
