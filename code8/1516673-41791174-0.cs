    Create(string Class, string Name, string JSONDeckList)
    {
        var deck = new Deck();
        deck.Class = Class; deck.Name = Name;
        // cards should be a IEnumerable<Card>
        foreach (var card in cards) {
            deck.DeckCards.Add(new DeckCard { Deck = deck, Card = card });
        }
    }
