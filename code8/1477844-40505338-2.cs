    List<items> itemsWon = new List<item>();
    float randomPercentage = Random.Range(0.0f, 1.0f);
    for(int i = 0; i < Bonus.Count; i++)
    {
        if (randomPercentage > Bonus[i].PERCENT)
        {
            itemsWon.Add(Bonus[i]);
        }
    }
