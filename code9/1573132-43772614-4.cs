    class Tester
    {
        static void Main(string[] args)
        {
            // Fill a new hand with your cards
            var hand = new Hand(new [] {
                new Card("Spade", 3),
                new Card("Club", 10),
                new Card("Diamond", 11),
                new Card("Heart", 9),
                new Card("Diamond", 13),
            });
            // "process" (display) your cards values
            hand.Process();
            // Shows the total hand value. This could also be moved into
            // the Process() function if you want
            Console.WriteLine("Total face value: {0}", hand.TotalFaceValue);
        } //end of static void main
    
    }//end of class Tester
    
    public class Hand
    {
        private readonly Card[] _cards;
        public Hand(Card[] cards)
        {
            _cards = cards;
        }
        public void Process()
        {
            foreach (var card in _cards)
            {
                card.DisplayCard();
            }
        }
        public int TotalFaceValue
        {
            get { return _cards.Sum(c => c.facevalue); }
        }
    }    
    class Card
    {
        public string suit { get; set; }
        public int facevalue { get; set; }
        public Card (string su, int fa) 
        {
            suit = su;
            facevalue = fa;
        }
        public void DisplayCard()
        {
            Console.WriteLine("The card is  {0,-10} {1,-10}", suit, facevalue);
    
        }
    }//end of class Card
