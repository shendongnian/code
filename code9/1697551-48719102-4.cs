	//String array with some of the patterns I'm looking for in the byte array
	string[] patterns = { "05805A6C", "0580306C", "05801B6C" };
	foreach (string p in patterns)
	{
        List<int> allIndices = new List<int>();
		int i=0;
        int indice = 0;
		// teminate loop when no more occurrence is found;
		// using a for loop with i++ is probably wrong since
		// it skips one additional character after a found pattern
		while (indice!=-1) 
        {
		    // index if the pattern is found AFTER i position, -1 if not
			indice = hex.IndexOf(p, i);
            // temporarily store the occured indices
            if (indice != -1) allIndices.Add(indice);
			i = indice+ 8; // skip the pattern occurrence itself
        }
        // does what it says :-)
        allIndices.Reverse();
        // separate loop for the output
        foreach (i in allIndices)
        {
		    //Do some calculations to get the offset I desire to register
			int index = (i / 2);
		    //Transform the index into hexadecimal
			string outputHex = int.Parse(index.ToString()).ToString("X");
		    //Output the index as an hexadecimal offset address
			MessageBox.Show("0x" + outputHex);
		}
	}
