    bool readingTargetSection = false;
	foreach (string line in File.ReadLines(_path))	
    {
        if (readingTargetSection)
        {
            if (line.Trim() == "") {
                // or just break out of the loop
                readingTargetSection = false;
            }
            else {
                // read the line
            }
        }		
		else if (line == check)
    	{
            readingTargetSection = true;
        }
    }
