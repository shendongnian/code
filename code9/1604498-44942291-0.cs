    public static void Store(IList<DrawNew> observingData)
    {
      var fileCounts
        = new Dictionary<bool, int>
          {
            { false, 0 },
            { true, 0 }
          };
      bool? pass = null;
      var lines = new List<DrawNew>();
      foreach (var drawNew in observingData)
      {
        if (pass.HasValue == false)
        {
          pass = drawNew.Pass;
        }
        if (pass.Value != drawNew.Pass)
        {
          if (lines.Any())
          {
            fileCounts[pass.Value]++;
            StoreLines(lines, pass.Value.ToString() + fileCounts[pass.Value] + ".csv");
          }
          lines.Clear();
          pass = drawNew.Pass;
        }
        lines.Add(drawNew);
      }
      if (pass.HasValue && lines.Any())
      {
        fileCounts[pass.Value]++;
        StoreLines(lines, pass.Value.ToString() + fileCounts[pass.Value] + ".csv");
      }
    }
    public static void StoreLines(IEnumerable<DrawNew> lines, string fileName)
    {
      // TODO: actually write the DrawNew items to the given file
    }
