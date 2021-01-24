    using (StreamReader sr = new StreamReader(FileName)){
	while (!sr.EndOfStream) 
	{
		// read every line
		line = sr.ReadLine(); 
		
		// if line is empty
		if (string.IsNullOrEmpty(line.Trim(' '))) // if you want to handle a line with a space as empty use trim for spaces
		{
			//... do something
		}
	}
    }
