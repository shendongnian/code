    for (var x = 0; x < Math.Max(Titles.Count, Text.Count); x++)
    {
      if (Titles.Count > x)
      {
        Console.WriteLine($"Title: {Titles[x].Text}");
      }
      if (Text.Count > x)
      {
        Console.WriteLine($"Article Text: {Text[x].Text}");
      }
    }
