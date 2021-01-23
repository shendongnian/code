    public struct Card
    {
      public string Name;
      public int Value;
    }
    private int random()
    {
      // Whatever
      return 1;
    }
    private static Card[] Cards = new Card[]
    {
        new Card() { Name = "7", Value = 7 },
        new Card() { Name = "8", Value = 8 },
        new Card() { Name = "9", Value = 9 },
        new Card() { Name = "10", Value = 10 },
        new Card() { Name = "J", Value = 1 },
        new Card() { Name = "Q", Value = 1 },
        new Card() { Name = "K", Value = 1 },
        new Card() { Name = "A", Value = 1 }
    };
    private void CardDemo()
    {
      int value, maxVal;
      string name;
      Card card, card2;
      List<Card> lowCards;
      value = Cards[random()].Value;
      name = Cards[random()].Name;
      card = Cards[random()];
      card2 = Cards[1];
      // card.Equals(card2) returns true
      lowCards = Cards.Where(x => x.Value == 1).ToList();
      maxVal = Cards.Max(x => x.Value);
    }
