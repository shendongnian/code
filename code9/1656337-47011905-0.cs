    var inputLines = File.ReadAllLines(@"E:\File.csv");
    var lineList = file.Select(x => x.Split(',').ToList()).
    Dictionary<int,int> dictIndexLenght = new Dictionary<int,int>();
	foreach(var line in inputLines)
	{
		List<string> columList =  line.Split(',').ToList();
		for (int i = 0; i < columList.Count; i++)
        {
	    	int tempVal = 0;
            if(dictIndexLenght.TryGetValue(i,out tempVal))
			{
				if(tempVal<columList[i].Length)
		    	{
			    	dictIndexLenght[i]=columList[i].Length;
				}				   
			}
			else
				dictIndexLenght[i]=columList[i].Length;
        }
		
    }
