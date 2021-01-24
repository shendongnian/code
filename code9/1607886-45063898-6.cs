    public static void BeverageRun()
    {
        var crate = new List<BeverageData>();
        //Add some items to it
        var newBeverage= new BeverageData();
        newBeverage.Name = "Fanta";
        newBeverage.Price = 0.75M;
        newBeverage.Type = "Soda";
        crate.Add(newBeverage);
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
