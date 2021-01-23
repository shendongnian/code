    static void Main(string[] args)
    {
        string listPath = @"K:\listData\listData.txt";
        int listDataSum = 0;
        int listDataMax = 0;
        int listDataMin = 0;
        string userInput = null;
        var fileReader = System.IO.File.StreamReader(listPath);
        List<string> stringsFromFile = new List<string>();
        while(string lineOfText = fileReader.ReadLine() != null)
        {
            stringsFromFile.Add(lineOfText);
        }
        List<int> intsFromFile = new List<int>();
        foreach(string s in stringsFromFile)
        {
            int temp = 0;
            if(Int32.TryParse(s, out temp))
            {
                intsFromFile.Add(temp);
            }            
        }
        listDataSum = intsFromFile.Sum();
        listDataMax = intsFromFile.Max();
        listDataMin = intsFromFile.Min();
        Console.WriteLine("Please input the data you wish to see, type 'help' for what to type");
        userInput = Console.ReadLine();
        userInput.ToLower();
        if (userInput == "sum")
        {
            Console.WriteLine("The sum of the list is " + listDataSum);
        }
    }
