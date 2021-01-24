    Console.WriteLine("Skriv in Fahrenheit: ");
    double fahr;
    double tempCels;
    bool isInputCorrect = false;
    while (!isInputCorrect)
    {
        var input = Console.ReadLine();
        if (!double.TryParse(input, out fahr))
        {
            Console.WriteLine("Du kan bara skriva in siffor, testa igen.");
            continue;
        }
        tempCels = FahrToCels(fahr);
        if (tempCels < 73)
        {
            Console.WriteLine("Temperaturen är för kallt, skruva upp lite!");
            continue;
        }
        else if (tempCels > 77)
        {
            Console.WriteLine("Temperaturen är för varmt, skruva ner lite!");
            continue;
        }
        isInputCorrect = true;
    }
    Console.WriteLine("Temperaturen är nu bra, hoppa in! tempCels : " + tempCels);
    Console.ReadKey();
