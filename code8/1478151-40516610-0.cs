    ///<summary>
    /// Function to show current cards
    /// </summary>
    public static void ViewCards(object player)
    {
        var cards = (player as Player)?.Cards;  // cast object to Player, returs null if object is not of correct type
        if (cards != null)
        {
           foreach (var card in cards)
           { 
               Console.WriteLine($"{card.Name}");
               Console.WriteLine($"Attack: {card.Attack}");
               Console.WriteLine($"Defense: {card.Defense}");
               Console.WriteLine($"Cost: ${card.Cost}");
           }  
        }    
    }
