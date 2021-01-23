    var random = new Random();
    var sentences = new List<string>
    {
        "Test Hello!",
        "Test2 Hello hows your day!",
        "How are you today sir?"
    };
    Console.Write("How many random sentences would you like to print?: ");
    var count = 0;
    // Convert user input into the integer count variable, and continually print an error message 
    // if the input is not an integer or if the integer is less than 0
    while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
    {
        Console.WriteLine("Please enter a positive integer: ");
    }
    // Print out a random sentence for x (count) amount of times.
    while (count > 0)
    {
        // Will generate an index within the range of the list
        var index = random.Next(0, sentences.Count() - 1);
        Console.WriteLine(sentences[index]);
        count--;
    }
    // Prevents the console from closing after the program is done executing.
    Console.WriteLine("Press any key to exit the application...");
    Console.ReadKey();
