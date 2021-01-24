    var tmpFile = Path.GetTempFileName();
    using (StreamReader sr = new StreamReader(logF))
    {
        using (StreamWriter sw = new StreamWriter(tmpFile))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                foreach (var replacement in replacements)
                    line = line.Replace(replacement.Key, replacement.Value);
                
                sw.WriteLine(line);
            }
        }
    }
    File.Replace(tmpFile, logF, null);// you can pass backup file name instead on null if you want a backup of logF file
