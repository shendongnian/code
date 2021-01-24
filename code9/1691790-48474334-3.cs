    string firstMatchedNameIfAny = null;
    
    for (int i = 0 ; i < cardSetWithWordCounts.Count ; i++)
    {
        if (cardSetWithWordCounts[i].IsToggled)
        {
            if (firstMatchedName == null)
            {
                firstMatchedName = cardSetWithWordCounts[i].Name;
            }
            else
            {
                return "mixed";
            }
        }
    }
    
    return firstMatchedNameIfAny;
