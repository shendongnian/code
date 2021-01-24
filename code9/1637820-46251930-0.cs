    object[] RA = { "Ram", 123, 122 };
    for (int i = 0; i <  RA.Length; i++) {
      var r = RA[i];
      if (r is string s) {
        Console.WriteLine($"{i}: string \"{s}\"");
      } else if (r is int x) {
        Console.WriteLine($"{i}: int {x}");
      } else {
        Console.WriteLine($"{i}: {r.GetType().Name}");
      }
    }
