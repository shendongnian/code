    bool readingTargetSection = false;
	foreach (string line in File.ReadLines(_path))	
    {
        if (readingTargetSection)
        {
            // read the line
        }		
		else if (line == check)
    	{
            readingTargetSection = true;
        }
    }
