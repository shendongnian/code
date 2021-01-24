    void Main()
    {
    	SearchAndDestroy("c:\\");
    }
    
    static void SearchAndDestroy(string folder)
    {
    	Parallel.ForEach(Directory.GetFiles(folder, "*.lnk"), file =>
    	 {
    		try
    		 {
    
    			 if (File.ReadLines(file).Any(line => line.Contains("your.exe")))
    			 {
    				 // delete it
    			 }
    		 }
    		 catch (Exception)
    		 {
    
    			 // inaccesible file
    		 }
    	 });
    
    	Parallel.ForEach(Directory.GetDirectories(folder), subDir =>
    	 {
    		 try
    		 {
    			 SearchAndDestroy(subDir);
    		 }
    		 catch
    		 {
    			 // inaccesible dir.
    		 }
    	 });
    }
