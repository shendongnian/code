    var header = new Header
    {
        HeaderId = 1,
    }.Add(new Line { },
          new Line { },
          new Line { });
    foreach (var line in header.Lines)
        Console.WriteLine($"{line.HeaderId}-{line.LineId}");
    /*
    1-0
    1-1
    1-2
    */
