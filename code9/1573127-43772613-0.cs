    private static void Main(string[] args)
        {
            Card[] hand =
                {
                    new Card("Spade", 3),
                    new Card("Club", 10),
                    new Card("Diamond", 11),
                    new Card("Heart", 9),
                    new Card("Diamond", 13),
                };
            ProcessHand(hand);
            Console.WriteLine(Sum(hand.Select(x=>x.facevalue).ToArray()));
        }
        static int Sum(params int[] facevalue)// <- trying to calculate sum of facevalues of cards.
        {
            return facevalue.Sum();
        }
