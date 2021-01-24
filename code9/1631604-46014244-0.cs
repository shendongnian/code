    int lineCount = 5;
    int colCount = 5;
    var list2D = Enumerable
      .Range(0, lineCount)   // 5 lines
      .Select(line => Enumerable
         .Range(0, colCount) // 5 columns
         .Select(column => colCount * line + column + 1)
         .ToList())
      .ToList();
