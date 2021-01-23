        string[] stringArray= {"AAA", "BBB", "CCC","DDD", "EEE","FFF","GGG","HHH" };
		string[] stringArray1 = { "A", "B", "C","D", "E","F","G","H" };
		string[] stringArray2 = { "BBB", "DDD","FFF","HHH" };
		
		//convert string array to hashset
		var hashSet = new HashSet<string>(stringArray);
		int j=0;
		string line = null;
		List<string> finalstring = new List<string>();
		for (int i = 0; i < stringArray2.Length; i++)
		{
   			if(hashSet.Contains(stringArray2[i]))
   			{
      			//if only first charracter is needed
      			finalstring.Add(new string(stringArray2[i][0], 1));
   			}
		} 
