      int questionCount = 3;
      string caption = string.Join("\t", Enumerable
        .Range(1, questionCount)
        .Select(index => $"Question {index}"));
      var body = string.Join(Environment.NewLine, Enumerable
        .Range(0, 1 << questionCount)
        .Select(i => Convert
           .ToString(i, 2)
           .PadLeft(questionCount, '0')
           .Select(c => c == '0' ? "False" : "True"))
        .Select(items => string.Join("\t", items)));
      string report = string.Join(Environment.NewLine, caption, body);
      Console.WriteLine(report);
