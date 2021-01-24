    for (int j = 0; j <= 5; j++)
            {
                for (int i = 0; i <= 2; i++)
                {
                    int randomNumber = random.Next(0, 9);
                    if (clue.Contains(randomNumber))
                    {
                        i--;
                    }
                    else
                    {
                        clue.Add(randomNumber);
                    }
    
                    if (clue.Count == 3) // EDIT: what if it never reaches 3 ?
                    {
                        clueList.Add(clue.ToList());
                        clue.Clear();
                    }
                }
            }
