      uisng System.Linq;
      using System.Numerics;
      uisng System.Reflection;
      ...
      var result = typeof(BigInteger)
        .Assembly
        .GetCustomAttributes()
        .Select(attr => attr.GetType().Name)
        .ToArray();
      Console.Write(string.Join(Environment.NewLine, result));
