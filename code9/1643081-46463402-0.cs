      using System.Numerics;
      ...
      int input = 12;
      string report = string.Join(Environment.NewLine, Enumerable
        .Range(0, input)
        .Select(index => BigInteger.Pow(2, index)));
      Console.Write(report);
