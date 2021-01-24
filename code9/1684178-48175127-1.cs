    var evenNumbers = new List<int>();
    // Infinite loop is broken at the 'break' line below
    while (true)
    {
        // If the user enters a valid integer, TryParse will store it in this
        int result;
        // We read a line from the console and pass it to int.TryParse, which will
        // return 'true' if the input is a valid int and will store it in 'result'
        // If it returns false, then we break from the loop
        if (!int.TryParse(Console.ReadLine(), out result)) break;
        // If the number entered is Even, add it to our list
        if (result % 2 == 0) evenNumbers.Add(result);
    }
    // If there are any items in our list, then print them. Otherwise print "N/A"
    if (evenNumbers.Count > 0)
    {
        foreach (var evenNumber in evenNumbers)
        {
            Console.WriteLine(evenNumber);
        }
    }
    else
    {
        Console.WriteLine("N/A");
    }
