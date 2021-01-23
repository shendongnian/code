    var projectFolders = Directory.GetDirectories(@"Projects/");
    var fileEligibleToBeMoved = new List<string>();
    
    var files = Directory.GetFiles(Directory.GetCurrentDirectory());
    foreach (var file in files)
    {
    	if (!file.Contains(".CID"))
    		continue;
    	var fileName = Path.GetFileName(file);
    	var matches = Regex.Matches(fileName, @"(P[a-zA-Z0-9]+)");
    
    	if (matches.Count == 0)
    		continue;
    
    	var isEligible = true;
    	var previous = string.Empty;
    	foreach (Match match in matches)
    	{
    		if(previous == string.Empty)
    		{
    			previous = match.Value;
    			continue;
    		}
    		if (previous != match.Value)
    			isEligible = false;
    	}
    	if (isEligible)
    		fileEligibleToBeMoved.Add(file);                
    }
    
    foreach (var dir in projectFolders)
    {
    	var panelTag = Regex.Match(dir, @"-\w+").Value.Replace("-", "");                
    	var filesToMove = fileEligibleToBeMoved
    		.Where(file => file.Contains(panelTag))
    		.ToArray();
    	foreach (var file in filesToMove)
    	{
    		
    		File.Move(file, string.Format("{0}/{1}", dir, Path.GetFileName(file)));
    	}
    }
