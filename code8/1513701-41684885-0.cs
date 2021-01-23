    IList<Card> group = new List<Card>();
    IList<Card> result = new List<Card>();
    for (int i = 0, j = 0; i < cardList.Count - 1; i++)
    {
        group.Clear();
        group.Add(cardList[i]);
        for (j = i + 1; j < cardList.Count; j++, i++)
        {
            if (cardList[j].Amount == cardList[i].Amount && cardList[j].CardNumber - cardList[i].CardNumber == 1)
            {
                group.Add(cardList[j]);
            }
            else break;
        }
        if (4 > group.Count)
        {
            foreach (var item in group)
            {
                result.Add(new Card { Amount = item.Amount, DisplayText = item.CardNumber.ToString() });
            }
        }
        else
        {
            result.Add(new Card { Amount = group[0].Amount, DisplayText = string.Format("{0} - {1}", group[0].CardNumber, group.Last().CardNumber) });
        }
    }
