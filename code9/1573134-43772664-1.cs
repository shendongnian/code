        class Card
        {
            public string Suit { get; }
            public int FaceValue { get; }
            public Card(string su, int fa)
            {
                Suit = su;
                FaceValue = fa;
            }
            public void DisplayCard()
            {
                Console.WriteLine("The card is  {0,-10} {1,-10}", Suit, FaceValue);
            }
            public static int Sum(Card[] cards)
            {
                return cards.Sum(c => c.FaceValue);
            }
        }
