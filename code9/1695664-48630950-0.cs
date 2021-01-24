    public static List<string> FindClosestPrefixMatches(string directory, string filePrefix, 
        string fileSuffix)
    {
        var result = new List<string>();
        if (!Directory.Exists(directory)) return null;
        // Loop removes one character from filePrefix on each search iteration
        for (int i = filePrefix.Length; i > 0; i--)
        {
            var wildcardName = filePrefix.Substring(0, i) + "*" + fileSuffix;
            var files = Directory.GetFiles(directory, wildcardName);
            if (files.Any())
            {
                result.AddRange(files);
                break;
            }
        }
        return result;
    }
