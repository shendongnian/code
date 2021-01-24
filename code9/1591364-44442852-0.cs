    private static string fileCount(string sDir, string sfileType)
    {
        int count = 0;
        string extension;
        List<string> directoriesToCheck = Directory.GetDirectories(sDir).ToList();
        directoriesToCheck.Add(sDir);
        foreach (string d in directoriesToCheck)
        {
            foreach (string file in Directory.GetFiles(d))
            {
                extension = System.IO.Path.GetExtension(file);
                if (extension.ToUpper().Equals(sfileType.ToUpper()))
                {
                    TimeSpan fileAge = DateTime.Now - File.GetLastWriteTime(file);
                    if (fileAge.Days > int.Parse(ConfigurationManager.AppSettings["numberOfDays"]))
                    {
                        count++;
                    }
                }
            }
        }
        return count.ToString();
    }
