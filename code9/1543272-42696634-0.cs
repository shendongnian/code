    //read all lines from file
    List<string>lines = File.ReadAllLines(@"pathToFile").ToList();
    int number = int.Parse(lines[0]);
    //list to hold first column
    List<int> firstList = new List<int>();
    //list to hold second
    List<int> secondList = new List<int>();
    for (int i = 1; i< lines.Count; i++) // iterate through all lines, starting at second (index 1)
    {
    	//split line by space
    	string[] numbersFromLine = lines[i].Split(' ');
    	//put first part of splitted line into list
    	firstList.Add(int.Parse(numbersFromLine[0]));
    	//put second part of splitted line into list
    	secondList.Add(int.Parse(numbersFromLine[1]));
    }
