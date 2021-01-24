    using System.Linq;
    public List<AvailableFile> GetAvailableFiles(string rootFolder, List<string> wordsToCompare)
    {
    	if (Directory.Exists(rootFolder))
    	{
    		try
    		{
    			foreach (string f in Directory.GetFiles(rootFolder))
    			{
    				if (wordsToCompare.Any(v => f.ToString().Contains(v)))
    				{
    					// create file
    				}
    			}
    		}
    		catch
    		{
    		// log stuff
    		}
    	}
    	return files;
    }
