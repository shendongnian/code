        static int ProcessHand(Card[] cards)
        {
            var sum = 0;
            foreach (var card in cards)
            {
                card.DisplayCard();
                sum += card.FaceValue;
            }
            return sum;
        }
