    foreach (var kvp in sizes)
    {
      Console.Write(kvp.Key.PadLeft(kvp.Value));
      Console.Write(" ");
    }
    Console.WriteLine();
