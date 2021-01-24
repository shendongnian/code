    int age = 0;
    string ageInput = Console.ReadLine();
    if (!int.TryParse(ageInput, out age))
    {
        // Parsing failed, handle the error however you like
    }
    // If parsing failed, age will still be 0 here.
    // If it succeeded, age will be the expected int value.
