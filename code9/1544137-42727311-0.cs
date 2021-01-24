    while ((line = file.ReadLine()) != null)
     {
    	
        string[] parts = line.Split('.', StringSplitOptions.RemoveEmptyEntries);
    	
    	string[] secondSplit = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    	
    	// put together the file path
    	string filePath = parts[0] + "." +  secondSplit[0];
    	
    	// Do something here with the rest of the second split: secondSplit
     }
