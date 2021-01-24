    var evenNumbers = new List<int>();
    // Infinite loop is exited by the 'break' command below
    while (true)
    {
        // If the user enters a valid integer, TryParse will store it in this
        int number;
        // We read a line from the console and pass it to int.TryParse, which will
        // return 'true' if the input is a valid int and will store it in 'number'
        // If it returns false, then we break from the loop
        if (!int.TryParse(Console.ReadLine(), out number)) break;
        // If the number entered is Even, add it to our list
        if (number % 2 == 0) evenNumbers.Add(number);
    }
    // If there are any items in our list, then print them. Otherwise print "N/A"
    if (evenNumbers.Count > 0)
    {
        foreach (int evenNumber in evenNumbers)
        {
            Console.WriteLine(evenNumber);
        }
    }
    else
    {
        Console.WriteLine("N/A");
    }
