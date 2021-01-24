    public enum CardColor
    {
        Club =0,
        Diamond =1,
        Hearth  = 2,
        Spade = 3
    }
    public class Card
    {
        public CardColor CardColor { get; set; }
        public int Value {get;set;}
        public Card(CardColor cardColor,int value) {
            CardColor = cardColor;
            Value = value;
        }
    }
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        //also instead on having a method to initialize the Deck you can do that
        // in the constructor of the Deck class
        public void InitilizeDeck()
        {
            foreach (var cardColor in Enum.GetValues(typeof(CardColor))) {
                for (int i = 1; i<=10;i++)
                {
                    Cards.Add(new Card((CardColor)cardColor, i));
                }
            }
        }
    }
      //then use the Deck class like that
      var deck = new Deck();
      deck.InitilizeDeck();
      var cards = deck.Cards;
