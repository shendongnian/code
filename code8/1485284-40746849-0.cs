    static void Main(string[] args)
    {
    	var firstDir = @"Path1";
    	var secondDir = @"Path2";
    
    	var firstDirFiles = System.IO.Directory.GetFiles(firstDir);
    	var secondDirFiles = System.IO.Directory.GetFiles(secondDir);
    	print2Dirs(firstDirFiles, secondDirFiles);
    
    }
    
    private static void print2Dirs(string[] firstDirFile, string[] secondDirFiles)
    {
    	var maxIndex = Math.Max(firstDirFile.Length, secondDirFiles.Length);
    	
    	using (StreamWriter streamWriter = new StreamWriter("result.txt"))
    	{
    		streamWriter.WriteLine(string.Format("{0,-150}{1,-150}", "Unique in fdr1", "Unique in fdr2"));
    		for (int i = 0; i < maxIndex; i++)
    		{
    			streamWriter.WriteLine(string.Format("{0,-150}{1,-150}",
    				firstDirFile.Length > i ? firstDirFile[i] : string.Empty,
    				secondDirFiles.Length > i ? secondDirFiles[i] : string.Empty));
    		}
    	}
    }
