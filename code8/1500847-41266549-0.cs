    // A list to hold all of the numbers entered
    List<int> numbers = new List<int>();
    // Will hold the inputted string
    string input;
		
    // This needs to be outside the loop so it's written once
    Console.Write("Numbers: " + Environment.NewLine);
		
    // Keep going until we say otherwise
    while (true)
    {
        // Get the input
        input = Console.ReadLine();
        // Will hold the outcome of parsing the input
	    int number = -1;
        // Check to see if input was a valid number
        bool success = int.TryParse(input, out number);
        // If it was a valid number then remember it
        // If ANY invalid or textual input is detected then stop
	    if (success)
			numbers.Add(number);
		else
			break;
    }
		
    // Write the count and average
	Console.WriteLine("Count:" + numbers.Count);
    Console.WriteLine("Average:" + numbers.Average());
    Console.ReadLine();
