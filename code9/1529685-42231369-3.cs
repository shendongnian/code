    List<double[]> fileData = System.IO.File.ReadAllLines(fileName)
              .Select(x => x.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Where((s, index) => index != 2) // filters out the third column
                 .Select(y => double.Parse(y))
                 .ToArray())
              .ToList();
