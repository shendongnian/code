    public static IEnumerable<T> Anomaly<T>(IEnumerable<T> source, 
                                            Func<T, double> map, 
                                            double maxSigma = 3.0) {
      if (null == source)
        throw new ArgumentNullException("source");
      else if (null == map)
        throw new ArgumentNullException("map");
      T[] data = source.ToArray();
      if (data.Length <= 1)
        yield break;
      double s = 0.0;
      double s2 = 0.0;
      foreach (var item in data) {
        double x = map(item);
        s += x;
        s2 += x * x;
      }
      double mean = s / data.Length;
      double sigma = Math.Sqrt(s2 / data.Length - (s / data.Length) * (s / data.Length));
      double leftMargin = mean - maxSigma * sigma;
      double rightMargin = mean + maxSigma * sigma;
      foreach (var item in data) {
        double x = map(item);
        if (x < leftMargin || x > rightMargin)
          yield return item;
      }
    }
