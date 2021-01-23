    // Accepting value from user 
    for (s = 0, g = 0,p=0; s <= 5; s++, g++,p++)
    {
        Console.Write("\nEnter your subject:\t");
        string input = Convert.ToString(Console.ReadLine());
        if (input.ToUpperInvariant() == "MATH")
        { /* do what ever is needed */}
        subjects[s] = input.ToUpperInvariant();
