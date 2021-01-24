    static Dictionary<string, List<string>> GetDupes2(string baseDir)
    {
    	Dictionary<string, List<string>> files = new Dictionary<string, List<string>>();
    
    	foreach (string f in Directory.EnumerateFiles(baseDir, "*.*", SearchOption.AllDirectories))
    	{
    		var fName = Path.GetFileName(f);
    		if (files.ContainsKey(fName))
    		{
    			files[fName].Add(f);
    		}
    		else
    		{
    			files.Add(fName, new List<string> { f });
    		}
    	}
    
    	return files;
    
    }
