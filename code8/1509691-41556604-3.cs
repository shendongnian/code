    // In order to avoid int.MaxValue, long.MaxValue borders let's return strings 
    private static IEnumerable<string> Generator(params int[] digits) {
      var vals = digits
        .Distinct()
        .OrderBy(x => x)
        .Select(x => x.ToString())
        .ToArray();
      Queue<string> agenda = new Queue<string>(vals);
      while (true) {
        string value = agenda.Dequeue();
        yield return value;
        foreach (var v in vals)
          agenda.Enqueue(value + v);
      }
    }
