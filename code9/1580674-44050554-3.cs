    private static IEnumerable<string[]> ExtractLines(IEnumerable<string> source) {
      List<string> group = new List<string>();
      
      foreach (var line in source) {
        if (line.Contains("machine - sequence Nr.")) {
          if (group.Any())
            yield return group.ToArray();
          group.Clear();
          group.Add(line);
        }
        else if (line.Contains("Stud machine point Nr.") || 
                 line.Contains("Stud Machine Failure"))
          if (!group.Contains(line)) // remove duplicates
            group.Add(line);
      }
      if (group.Any())
        yield return group.ToArray();
    }
    private static IEnumerable<String> MakeReport(IEnumerable<string> source) {
      bool firstLine = true;
      foreach (var group in ExtractLines(source)) {
        if (!firstLine)
          yield return "";
        firstLine = false;
        yield return (string.Join(Environment.NewLine, group));
      }
    }
