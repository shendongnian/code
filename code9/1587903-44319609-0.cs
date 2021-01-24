    // Present the options
    Console.WriteLine(" 1. Blue \r\n 2. Yellow \r\n 3. Red \r\n 4. Green");
    // This variable will hold their input after the TryParse call 
    int ColorChoiceNumberInt;
    // Continue to ask for input until they enter an integer between 1 and 4
    do
    {
        Console.Write("Select a color of Fish by entering the corresponding number (1-4): ");
    } while (!int.TryParse(Console.ReadLine(), out ColorChoiceNumberInt) ||
             ColorChoiceNumberInt < 1 ||
             ColorChoiceNumberInt > 4);
