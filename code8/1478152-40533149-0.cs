    public static void ViewCards(dynamic player)
    {
        var cards = player.Cards  // This line doesn't work
        foreach (var card in cards)
        {
            Console.WriteLine($"{card.Name}");
            Console.WriteLine($"Attack: {card.Attack}");
            Console.WriteLine($"Defense: {card.Defense}");
            Console.WriteLine($"Cost: ${card.Cost}");
        }    
    }
