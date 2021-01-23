    public bool CheckStraight(List<Card> cards)
    {
         //maybe check 5 and 10 here first for performance
         var ordered = cards.OrderByDescending(a => a.Value).ToList();
         for(i = 0; i < ordered.Count - 5; i++) {
              var skipped = ordered.Skip(i);
              var possibleStraight = skipped.Take(5);
              if(IsStraight(possibleStraight)) {
                   return true;
              }
         }
         return false;
    }
    public bool IsStraight(List<Card> fiveOrderedCards) {
         var doubles = cards.GroupBy(card => card.Rank).Count(group => group.Count() > 1);
         var inARow = cards[4] - cards[0] = 5; //Ace is 0
         return !doubles && inARow;
    }
