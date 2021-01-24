        using System.Linq;
        ...
        static long factorialmethod(int number) {
          if (number <= 1)
            return 1; // strictly speaking, factorial on negative (-N)! = infinity
          return Enumerable
           .Range(1, number)
           .AsParallel() // comment it out if you want sequential version
           .Aggregate(1L, (s, a) => s * a);
        }
