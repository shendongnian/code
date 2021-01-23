      double[,] source = ...
      List<List<double>> result = new List<List<double>>(source.GetLength(0));
      // please, notice <= comparison
      for (int i = source.GetLowerBound(0); i <= source.GetUpperBound(0); ++i) {
        List<double> line = new List<double>(source.GetLength(1));
        result.Add(line);
        // please, notice <= comparison
        for (int j = source.GetLowerBound(1); j <= source.GetUpperBound(1); ++j)
          line.Add(source[i, j]);
      }
