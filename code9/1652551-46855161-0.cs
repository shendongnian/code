    public class Deck {
        public Deck() {
            CardList = new List<Card>();
        }
        public List<Element> CardList { get; set; }
        public void DrawCard(int cardNumber) {
            var card = CardList[cardNumber];
            if (card.GetType() == typeof(Card)) {
                // Do something
            }
            else if (card.GetType() == typeof(BlueCard)) {
                // Do something
            }
            else if (card.GetType() == typeof(RedCard)) {
                // Do something
            }
        }
    }
