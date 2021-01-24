    foreach (var row in list)
    {
      foreach (var column in row)
      {
        var padding = sizes[column.Key];
        Console.Write(column.Value.PadLeft(padding));
        Console.Write(" ");
      }
      Console.WriteLine();
    }
