        string inputcost;
        string inputmoney;
        int validcost;
        Console.Write("Please Enter The Cost, In Pennies, Of The Item You Have Purchased: ");
        inputcost = Console.ReadLine();
        bool result = int.TryParse(inputcost, out validcost);
        while (!int.TryParse(inputcost, out validcost))
        {
            if (result == true)
            {
                Console.Write("Valid Value");
            }
            if (result == false)
            {
                Console.Write("Please Enter A Valid Integer Value");
                Console.WriteLine();
                inputcost = Console.ReadLine();
            }
        }
