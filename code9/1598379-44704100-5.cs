        using System.Linq;
        ...
        public static string multiplication(int num, int starting, int ending) {
          return string.Join(Environment.NewLine, Enumerable
            .Range(starting, ending - starting + 1)
            .Select(i => $"{num} x {i} = {num * i}"));
        }
        ...
        Console.Write(multiplication(3, 5, 7));
