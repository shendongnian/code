    private Dictionary<string, string> qa;
    public YourClassConstructor()
    {
      this.qa = File.ReadLines("qa.txt")
          .Select((line, index) => new {line, index})
          .GroupBy(x => x.index / 2)
          .ToDictionary(g => g.First().line.ToLower(), g => g.Last().line);
    }
