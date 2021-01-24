        int numberOfThreads = 8;
        List<ZipEntry> clonedZipEntries = new List<ZipEntry>();
        
        foreach(int i = 0; i < numberOfThreads; i++){
        	
        	//You may have to implement this yourself.
        	clonedZipEntries.Add(allZipEntries.Clone());
        }
        
        
        //Need to tell the parallel loop how many threads to use, then depending on which thread is active you access the appropriate cloned object
    //Most likely be easier to split the foreach into 8 individual foreach loops that run as tasks in parallel.
        Parallel.ForEach(allZipEntries, currentEntry =>
        {
        
        	if (currentEntry.FullName.Equals(currentEntry.Name))
        	{
        		currentEntry.ExtractToFile($"{tempPath}\\{currentEntry.Name}");
        	}
        	else
        	{
        		var subDirectoryPath = Path.Combine(tempPath, Path.GetDirectoryName(currentEntry.FullName));
        		Directory.CreateDirectory(subDirectoryPath);
        		currentEntry.ExtractToFile($"{subDirectoryPath}\\{currentEntry.Name}");
        	}
        	
        });
