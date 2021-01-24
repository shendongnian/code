    Program p = new Program();
    int MAX = 50;
    int[] grades = new int[MAX];
    string environment = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\";
    string path = environment + "grades.txt";
    using (StreamReader myFile = new StreamReader(path))
    {
    	string input;
    	int count = 0;
    	while((!myFile.EndOfStream) && (count < MAX))
    	{
    		input = myFile.ReadLine();
    		if (!String.IsNullOrWhiteSpace(input))
    		{
    			WriteLine(input);
    			grades[count] = int.Parse(input);
    			count++;
    		}
    	}
    }
