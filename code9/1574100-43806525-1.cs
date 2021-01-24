    var maxItems = (new int[] { Days.Length, Depths.Length, IRIS_IDs.Length,Latitudes.Length })
                   .Max();
    var reuslt = Enumerable.Range(0, maxItems)
              .Select(i => new Data
              {
                  Day = Days.ElementAtOrDefault(i),
                  Depth = Depths.ElementAtOrDefault(i),
                  IRIS_ID = IRIS_IDs.ElementAtOrDefault(i),
                  Latitude = Latitudes.ElementAtOrDefault(i)
              }).ToList();
