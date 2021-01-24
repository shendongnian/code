      string fileName = @"C:\MyFile.csv";
      var columns = File
        .ReadLines(fileName)
        .SkipWhile(line => !string.IsNullOrWhiteSpace(line))
        .FirstOrDefault()
        .Split(new char[] { '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
    // .Select(item => item.Trim()); // you may want to trim column names
