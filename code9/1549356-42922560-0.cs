    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();
                
        Console.WriteLine("Enter up to 10 numbers or type 0 to stop:");
    
        for (int i = 0; i < 10; i++)
        {
            int userInput = 0;
    
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Only integer numbers accepted, let's try again...:");
            }
    
            if (userInput == 0)
            {
                break;
            }
            else
            {
                numberList.Add(userInput);
    
                if (i < 9)
                {
                    Console.WriteLine("Yeah, {0} more number{1} to go!", (9 - i), (i == 8 ? "" : "s"));
                }
            }
        }
                
        double average = numberList.Average();
    
        for (int i = 0; i < numberList.Count; i++)
        {
            Console.WriteLine("#{0}: {1} - {2} = {3}", (i+1), numberList[i], average, (numberList[i] - average));
        }
    
        Console.ReadLine();
    }
