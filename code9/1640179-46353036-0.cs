    char c = (char)(size + 48);
    IEnumerable<string> pyramid = Enumerable.Range(1, size)
      .Reverse()
      .Select(i => new String(c, i);
    foreach(string line in pyramid)
    {
      Console.WriteLine(line);
    }
