    static void Main(string[] args)
    {
    	// Path to the file you want to read in
    	var filePath = "path/to/JUNK1.txt";
    
    	// This will give you back an array of strings for each line of the file
    	var fileLines = File.ReadAllLines(filePath);
    
    	// Loop through each line in the file
    	foreach (var line in fileLines)
    	{
    		// This will give you an array of all the values that were separated by a comma
    		var valuesSeparatedByCommas = line.Split(',');
            // Do whatever with the array valuesSeparatedByCommas
    	}
    }
