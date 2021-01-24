    public List<Card> Copy(List<Card> cards)
    {
        List<Card> cloneList = new List<Card>();
        foreach (var card in cards)
        {
            Card clone = new Card();
            clone.Property1 = card.Property1;
            // ... other properties
            cloneList.Add(clone);
        }
        return cloneList;
    }
