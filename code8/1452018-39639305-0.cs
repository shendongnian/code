    public bool CheckStraight(List<Card> cards)
        {
            //maybe check 5 and 10 here first for performance
            var ordered = cards.OrderByDescending(a => a.Value).ToList();
            for (var i = 0; i < ordered.Count - 4; i++)
            {
                var skipped = ordered.Skip(i);
                var possibleStraight = skipped.Take(5).ToList();
                if (IsStraight(possibleStraight))
                {
                    return true;
                }
            }
            return false;
        }
    public bool IsStraight(List<Card> cards)
    {
        return cards.GroupBy(card => card.Value).Count() == cards.Count() && cards.Max(card => (int)card.Value) - cards.Min(card => (int)card.Value) == 4;
        }
