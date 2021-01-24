    public static void BeverageRun()
    {
        var crate = new List<BeverageData>();
        //Add some items to it
        var beverage = new BeverageData();
        beverage.Name = "Fanta";
        beverage.Price = 0.75M;
        beverage.Type = "Soda";
        crate.Add(beverage);
        crate.Add(new BeverageData() { Name = "Pepsi", Price = 0.25M, Type = "Soda" });
        //Prompting the user
        crate.Add(PromptUserForBeverage());
        foreach (var beverage in crate)
        {
            Console.WriteLine(PrintBeverage(beverage));
        }
        Console.ReadLine();
    }
    static string PrintBeverage(BeverageData beverage)
    {
        return "Name: " + beverage.Name + ", Price: $" + beverage.Price + ", Type: " + beverage.Type;
    }
