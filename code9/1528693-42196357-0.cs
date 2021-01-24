    bool CheckIt(string path)
    {
    	IEnumerable<string> pathItems = path.Split(Path.DirectorySeparatorChar);
    	
    	var isFile = System.IO.File.Exists(path);
    	if (isFile)
    		pathItems = pathItems.Skip(1);
    		
    	if (Path.IsPathRooted(path))
    		pathItems = pathItems.Skip(1);
    		
    	return pathItems.Any();
    }
