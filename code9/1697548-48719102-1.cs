	//String array with some of the patterns I'm looking for in the byte array
	string[] patterns = { "05805A6C", "0580306C", "05801B6C" };
	foreach (string p in patterns)
	{
		int i=0;
        int indice = 0;
		// teminate loop when no more occurrence is found;
		// using a for loop with i++ is probably wrong since
		// it skips one additional character after a found pattern
		while (indice!=-1) 
        {
		    //I get the index if the pattern is found at i position
			indice = hex.IndexOf(p, i);
		    //Do some calculations to get the offset I desire to register
			i = indice+ 8;
			int index = (i / 2);
		    //Transform the index into hexadecimal
			string outputHex = int.Parse(index.ToString()).ToString("X");
		    //Output the index as an hexadecimal offset address
			MessageBox.Show("0x" + outputHex);
		}
	}
