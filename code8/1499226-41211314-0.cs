    static void SortItems(Items[] items)
    {
    
        Console.WriteLine("Choose field to sort (Name, Weapon, Strength)");
        string userInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            Items[] sortedItems;
            switch (userInput.Trim().ToLower())
            {
                case ("name"):
                    sortedItems = items.OrderBy(x => x.Name).ToArray();
                    break;
                case ("weapon"):
                    sortedItems = items.OrderBy(x => x.Weapon).ToArray();
                    break;
                case ("strength"):
                    sortedItems = items.OrderBy(x => x.Strength).ToArray();
                    break;
                default:
                    //return whatever for default
                    sortedItems = items.OrderBy(x => x.Name).ToArray();
                    break;
            }
    
            foreach (Items c in sortedItems)
            {
                Console.WriteLine("Name : {0} - Weapon: {1} - Total strength: {2}", c.Name, c.Weapon.Name,
                    c.strength().ToString());
            }
        }
