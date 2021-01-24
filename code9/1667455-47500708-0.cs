        bool onePair = false;
        bool twoPair = false;
        bool threeKind = false;
        bool fullHouse = false;
        for (int i = 0; i < diceResults.Length; i++)
        {
            if (diceResults[i] >= 2)
            {
                if(onePair == true) {
                    twoPair = true;
                }
                onePair = true;
            }
            if (diceResults[i] >= 3)
            {
                threeKind = true;
                for (int j = 0; j< diceResults.Length; j++)
                {
                    if (diceResults[k] == 2)
                    {
                        fullHouse = true;
                    }
                }
            }
        }
