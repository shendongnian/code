    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    [...]
    public void StoreSeparatedByPass(IList<DrawNew> observingData)
    {
      // keep the file numbers easily accessible
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
        // to differentiate between "starting with false" 
        // and "starting with true".
        // (only interesting on first item)
        if (pass.HasValue == false)
        {
          pass = drawNew.Pass;
        }
        if (pass.Value != drawNew.Pass)
        {
          // the value of drawNew.Pass changed, the previous "part" has ended.
          // now we need to do store the collected lines (if there are any)...
          if (lines.Any())
          {
            fileCounts[pass.Value]++;
            StoreLines(lines, pass.Value.ToString() + fileCounts[pass.Value] + ".csv");
          }
          // then clear the stored list for the next part...
          lines.Clear();
          // and change the part indicator.
          pass = drawNew.Pass;
        }
        lines.Add(drawNew);
      }
      // don't forget to store the last part...
      if (pass.HasValue && lines.Any())
      {
        fileCounts[pass.Value]++;
        StoreLines(lines, pass.Value.ToString() + fileCounts[pass.Value] + ".csv");
      }
    }
    public void StoreLines(IEnumerable<DrawNew> lines, string fileName)
    {
      // TODO: actually write the DrawNew items to the given filename
    }
