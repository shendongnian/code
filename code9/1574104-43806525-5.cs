    var maxItems = (new int[] { Days.Length, Depths.Length, IRIS_IDs.Length,Latitudes.Length })
                   .Max();
    var result = Enumerable.Range(0, items)
              .Select(i => string.Join("\t", new [] { Days.ElementAtOrDefault(i),
                                                     Depths.ElementAtOrDefault(i),
                                                     IRIS_IDs.ElementAtOrDefault(i),
                                                     Latitudes.ElementAtOrDefault(i) }));
