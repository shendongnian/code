    double fahr;
    bool isInputCorrect = false;
    while (!isInputCorrect)
    {
        var input = Console.ReadLine();
        if (!double.TryParse(input, out fahr))
        {
            Console.WriteLine("Du kan bara skriva in siffor, testa igen.");
            continue;
        }
        isInputCorrect = true;
    }
    double tempCels = FahrToCels(fahr);
