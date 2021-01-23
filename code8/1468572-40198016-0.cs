    while (!int.TryParse(inputcost, out validcost)) || validCost < 1 ||  validCost > 100)
    {
        Console.WriteLine("Please enter an integer between 1 and 100");
        inputCost = Console.ReadLine();
    }
