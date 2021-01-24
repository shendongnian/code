        public static void Main(string[] args)
        {
            Card[] hand = {
                          new Card("Spade", 3),
                          new Card("Club", 10),
                          new Card("Diamond", 11),
                          new Card("Heart", 9),
                          new Card("Diamond", 13),
                      };
            var sum = ProcessHand(hand);
            Console.WriteLine($"The sum is {sum}");
        }
