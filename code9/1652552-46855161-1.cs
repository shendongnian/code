    public class Deck {
        public Deck() {
            _cardArray = new Card[52];
        }
        private Card[] _cardArray;
        public void DrawCard(int cardNumber) {
            var card = _cardArray[cardNumber];
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
