    static void Main(string[] args)    
    {
        string listPath = @"K:\listData\listData.txt";
        var lines = File.ReadAllLines(listPath).ToList();
        var number = 0;
        var numbers = lines.Where(line => int.TryParse(line, out number)).Select(n => number).ToList();         
        Console.WriteLine("Please input the data you wish to see, type 'help' for what to type");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "sum")
        {
            Console.WriteLine("The sum of the list is " + ListDataSum(numbers));
        }
        Console.ReadLine();
    }
    private static int ListDataSum(List<int> list)
    {
        return list.Sum();
    }
