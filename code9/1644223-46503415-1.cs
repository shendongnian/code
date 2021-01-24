    boolean reading = true;
    List<int> numbers = new ArrayList();
    while(reading)
    {
        try
        {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 9 && number < 100) numbers.Add(number);
            else reading = false; // leave reading process if no 2-digit-number
        }
        catch (Exception ex)
        {
            // leave reading process by typing a character instead of a number;
            reading = false;
        }
    }
    
    if (numbers.Count() > 1)
    {
        List<int> combined = new ArrayList();
        for (int i = 1; i <= numbers.Count(); i++)
        {
            combined.Add((numbers[i-1] % 10) + (numbers[i] - (numbers[i] % 10)));
        }
    
        //Logging output:
        foreach (int combination in combined) Console.WriteLine(combination);
    }
