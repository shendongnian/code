    public class Deck
    {
        private List<Card> cards;
    
        public IReadOnlyList<Card> Cards
        {
            get
            {
                return cards.AsReadOnly();
            }
        }
    
        public Deck()
        {
            cards = new List<Card>();
        }
    
        public Deck(IEnumerable<Card> cards)
        {
            cards = cards.ToList();
        }
    
        public Deck Concat(Deck other)
        {
            return new Deck(Cards.Concat(other.Cards));
        }
    
        public void AddRange(Deck other)
        {
            cards.AddRange(other.Cards);
        }
    }
