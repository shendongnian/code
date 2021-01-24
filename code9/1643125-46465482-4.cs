      ...
      var bodyLines = Enumerable
        .Range(0, 1 << questionCount)
        .Select(i => Convert
          .ToString(i, 2)
          .PadLeft(questionCount, '0')
          .Select(c => c == '0' ? "False" : "True"))
          .Select(items => string.Join("\t", items));
    
       Console.WriteLines(caption);
    
       foreach (var line in bodyLines)
         Console.WriteLines(line);
