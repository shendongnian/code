       public void BuyMerchandise(PlayerStats player)
        {
            Console.WriteLine("What would you like to purchase? \n");
            ViewInventory(player);
            switch (GetChoice())
            {
                case "1":
                    Price();
                    int statItems = player.LuxuryWatches;
                    Buy(player, "Luxury Watches", _LuxuryWatches, ref statItems);
                    player.LuxuryWatches = statItems;
                    break;
                case "2":
                    Price();
                    int statItems = player.LuxuryHandbags;
                    Buy(player, "Luxury Handbags", _LuxuryHandbags, ref statItems);
                    player.LuxuryHandbags = statItems;
                    break;
