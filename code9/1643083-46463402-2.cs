      // Let's use BigInteger instead of Double to represent 2's powers
      using System.Numerics;
      ...
      int input = 12;
      string report = string.Join(Environment.NewLine, Enumerable
        .Range(0, input)
        .Select(index => BigInteger.Pow(2, index)));
      Console.Write(report);
