    boolean reading = true;
    List<int> numbers = new ArrayList();
    while(reading)
    {
        try
        {
            // You should also check if the ReadLine() returns a two digit number.
            numbers.Add(Convert.ToInt32(Console.ReadLine()));
        }
        catch (Exception ex)
        {
            // leave the reading process by typing a character instead of a number;
            reading = false;
        }
    }
    
    if (numbers.Count() > 1)
    {
        List<int> combined = new ArrayList();
        for (int i = 1; i <= numbers.Count(); i++)
        {
            combined.Add(numbers[i-1] % 10) + (numbers[i] - (numbers[i] % 10));
        }
    
        //Logging output:
        foreach (int combination in combined) Console.WriteLine(combination);
    }
