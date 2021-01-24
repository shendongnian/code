    using (ZipArchive bfpFile = new ZipArchive(new FileStream(filename, 
    FileMode.Open))) {
    await Task.WhenAll(bfpFile.Entries.Select(s => Task.Run(() =>
    {
        if (s.FullName.EndsWith(".log", StringComparison.OrdinalIgnoreCase) && s.Name.Split('.').First().All(char.IsDigit) == true && s.Name.Split('.').Count() == 2)
        {
             string extractPath = Path.Combine(@"C:\LogFiles\Extracted\" + filename.Split('\\')[3].ToString() + @"\", s.Name);
             s.ExtractToFile(extractPath, true)));
         }
    }
    )));
    }
