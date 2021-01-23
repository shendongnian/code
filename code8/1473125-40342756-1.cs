    private static string Encode(int value) {
      return $"+ {value % 256} + {value / 256}";
    }
..
    // + 232 + 3
    Console.WriteLine(Encode(1000));
    // + 14 + 19
    Console.WriteLine(Encode(4878));
