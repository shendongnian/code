    static void Main(string[] args)
    {
    
        int number, sum = 0, n;
    
        List<int> inputNumbers = new List<int>();
        for(number = 0; number < 10; number++)
        {
            inputNumbers.Add(Convert.ToInt32(Console.ReadLine()));
        }
    
        // Obtain maximum and minimum values
        var maximum = inputNumbers.Max();
        var mimimum = inputNumbers.Min();
    
        foreach (var item in inputNumbers)
        {
            if(item == maximum)
            {
                inputNumbers.Remove(item);
                break;
            }
        }
    
        foreach(var item in inputNumbers)
        {
            if(item == mimimum)
            {
                inputNumbers.Remove(item);
                break;
            }
        }
    
        Console.WriteLine("Sum: "+inputNumbers.Sum());
        Console.ReadKey();
    }
