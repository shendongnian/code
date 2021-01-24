    using System.Linq;
    ...
    int[] numbers = new int[] { 5, 3, 1, 2, 2, 6, 8 };
    Console.WriteLine(string.Join(Environment.NewLine, numbers
      .Select((value, entry) => $"Entry {entry + 1} - {value}")));
