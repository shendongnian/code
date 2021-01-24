    List<double[]> fileData = new List<double[]>();
    fileData = System.IO.File.ReadAllLines(fileName)
              .Select(x => x.Split(new char[] { '\t', ' ' },
                      StringSplitOptions.RemoveEmptyEntries)
              .Where(s=>s.Contains(".")
              .Select(y => double.Parse(y))
              .ToArray())
              .ToList();
