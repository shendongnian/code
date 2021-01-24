    for (int j = 0; j <= 5; j++)
    {
        var list = new List<int>();
        for (int i = 0; i <= 2; i++)
        {
            int randomNumber = random.Next(0, 9);
            if (list.Contains(randomNumber))
            {
                i--;
            }
            else
            {
                list.Add(randomNumber);
            }
            if (list.Count == 3)
            {
                clueList.Add(list);
            }
        }
    }
