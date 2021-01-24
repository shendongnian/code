          // Simple: quotation has not been implemented
          // Disclamer: demo only, do not use your own CSV readers
          public static IEnumerable<string[]> ReadCsvSimple(string file, char delimiter) {
            return File
              .ReadLines(file)
              .Where(line => !string.IsNullOrEmpty(line))
              .Select(line => line.Split(delimiter));
          }
