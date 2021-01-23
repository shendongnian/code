      double[,] source = ...
      List<List<double>> result = new List<List<double>>(source.GetLength(0));
      for (int i = 0; i < source.GetLength(0); ++i) {
        List<double> line = new List<double>(source.GetLength(1));
        result.Add(line);
        for (int j = 0; j < source.GetLength(1); ++j)
          line.Add(source[i, j]);
      }
