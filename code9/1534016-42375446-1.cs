    int VillainId = -1;
    bool parseOK = false;
    do
    {
        Console.Write("Enter VillainId: ");
        parseOK = int.TryParse(Console.ReadLine(), out VillainId);
        if (!parseOK)
        {
            Console.WriteLine("You need to enter a valid Villain Id!");
        }
    } while (! parseOK);
