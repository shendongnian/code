        public void Buy(PlayerStats player, string myName, int myItem, ref int statItem)
    {
        Console.WriteLine("{0} Costs {1:C} per unit.", myName, myItem);
        int MaxPurchase = player.Money / myItem;
        Console.WriteLine("You can afford {0} units.", MaxPurchase);
        Console.WriteLine("How many units would you like to purchase?");
        string Purchasex = Console.ReadLine();
        int ammount = int.Parse(Purchasex);
        player.Money -= (myItem * ammount);
        statItem += ammount;
        Console.WriteLine("You have Purchased {0} units at {1:C} per unit.", ammount, myItem);
        Console.ReadLine();
    }
     
